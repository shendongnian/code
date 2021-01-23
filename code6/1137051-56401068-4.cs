    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using Microsoft.Owin.Hosting;
    using SignalrDomain;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ServiceProcess;
    using System.Threading;
    
    namespace SignalRBroadcastServiceSample
    {
        public partial class CurrencyExchangeService : ServiceBase
        {
            private Thread mainThread;
            private bool isRunning = true;
            private Random random = new Random();
    
            protected override void OnStart(string[] args)
            {
                WebApp.Start("http://localhost:8083"); // Must be 
                	//@"http://+:8083" if you want to connect from other computers
                LoadDefaultCurrencies();
    
                // Start main thread
                mainThread = new Thread(new ParameterizedThreadStart(this.RunService));
                mainThread.Start(DateTime.MaxValue);
            }
    
            protected override void OnStop()
            {
                mainThread.Join();
            }
    
            public void RunService(object timeToComplete)
            {
                DateTime dtTimeToComplete = timeToComplete != null ? 
                	Convert.ToDateTime(timeToComplete) : DateTime.MaxValue;
    
                while (isRunning && DateTime.UtcNow < dtTimeToComplete)
                {
                    Thread.Sleep(15000);
                    NotifyAllClients();
                }
            }
    
            // This line is necessary to perform the broadcasting to all clients
            private void NotifyAllClients()
            {
                Currency currency = new Currency();
                currency.CurrencySign = "CAD";
                currency.USDValue = random.Next();
                BroadcastCurrencyRate(currency);
                Clients.All.NotifyChange(currency);
            }
    
            #region "SignalR code"
    
            // Singleton instance
            private readonly static Lazy<CurrencyExchangeService> 
            	_instance = new Lazy<CurrencyExchangeService>(
                () => new CurrencyExchangeService
                (GlobalHost.ConnectionManager.GetHubContext<CurrencyExchangeHub>().Clients));
    
            private readonly object _marketStateLock = new object();
            private readonly object _updateCurrencyRatesLock = new object();
    
            private readonly ConcurrentDictionary<string, 
            	Currency> _currencies = new ConcurrentDictionary<string, Currency>();
    
            // Currency can go up or down by a percentage of this factor on each change
            private readonly double _rangePercent = 0.002;
    
            private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
    
            public TimeSpan UpdateInterval
            {
                get { return _updateInterval; }
            } 
    
            private readonly Random _updateOrNotRandom = new Random();
    
            private Timer _timer;
            private volatile bool _updatingCurrencyRates;
            private volatile MarketState _marketState;
    
            public CurrencyExchangeService(IHubConnectionContext<dynamic> clients)
            {
                InitializeComponent();
    
                Clients = clients;
            }
    
            public static CurrencyExchangeService Instance
            {
                get
                {
                    return _instance.Value;
                }
            }
    
            private IHubConnectionContext<dynamic> Clients
            {
                get;
                set;
            }
    
            public MarketState MarketState
            {
                get { return _marketState; }
                private set { _marketState = value; }
            }
    
            public IEnumerable<Currency> GetAllCurrencies()
            {
                return _currencies.Values;
            }
    
            public bool OpenMarket()
            {
                bool returnCode = false;
    
                lock (_marketStateLock)
                {
                    if (MarketState != MarketState.Open)
                    {
                        _timer = new Timer(UpdateCurrencyRates, null, _updateInterval, _updateInterval);
    
                        MarketState = MarketState.Open;
    
                        BroadcastMarketStateChange(MarketState.Open);
                    }
                }
                returnCode = true;
    
                return returnCode;
            }
    
            public bool CloseMarket()
            {
                bool returnCode = false;
    
                lock (_marketStateLock)
                {
                    if (MarketState == MarketState.Open)
                    {
                        if (_timer != null)
                        {
                            _timer.Dispose();
                        }
    
                        MarketState = MarketState.Closed;
    
                        BroadcastMarketStateChange(MarketState.Closed);
                    }
                }
                returnCode = true;
    
                return returnCode;
            }
    
            public bool Reset()
            {
                bool returnCode = false;
    
                lock (_marketStateLock)
                {
                    if (MarketState != MarketState.Closed)
                    {
                        throw new InvalidOperationException
                        	("Market must be closed before it can be reset.");
                    }
                    
                    LoadDefaultCurrencies();
                    BroadcastMarketReset();
                }
                returnCode = true;
    
                return returnCode;
            }
    
            private void LoadDefaultCurrencies()
            {
                _currencies.Clear();
    
                var currencies = new List<Currency>
                {
                    new Currency { CurrencySign = "USD", USDValue = 1.00m },
                    new Currency { CurrencySign = "CAD", USDValue = 0.85m },
                    new Currency { CurrencySign = "EUR", USDValue = 1.25m }
                };
    
                currencies.ForEach(currency => _currencies.TryAdd(currency.CurrencySign, currency));
            }
    
            private void UpdateCurrencyRates(object state)
            {
                // This function must be re-entrant as it's running as a timer interval handler
                lock (_updateCurrencyRatesLock)
                {
                    if (!_updatingCurrencyRates)
                    {
                        _updatingCurrencyRates = true;
    
                        foreach (var currency in _currencies.Values)
                        {
                            if (TryUpdateCurrencyRate(currency))
                            {
                                BroadcastCurrencyRate(currency);
                            }
                        }
    
                        _updatingCurrencyRates = false;
                    }
                }
            }
    
            private bool TryUpdateCurrencyRate(Currency currency)
            {
                // Randomly choose whether to update this currency or not
                var r = _updateOrNotRandom.NextDouble();
                if (r > 0.1)
                {
                    return false;
                }
    
                // Update the currency price by a random factor of the range percent
                var random = new Random((int)Math.Floor(currency.USDValue));
                var percentChange = random.NextDouble() * _rangePercent;
                var pos = random.NextDouble() > 0.51;
                var change = Math.Round(currency.USDValue * (decimal)percentChange, 2);
                change = pos ? change : -change;
    
                currency.USDValue += change;
                return true;
            }
    
            private void BroadcastMarketStateChange(MarketState marketState)
            {
                switch (marketState)
                {
                    case MarketState.Open:
                        Clients.All.marketOpened();
                        break;
                    case MarketState.Closed:
                        Clients.All.marketClosed();
                        break;
                    default:
                        break;
                }
            }
    
            private void BroadcastMarketReset()
            {
                Clients.All.marketReset();
            }
    
            private void BroadcastCurrencyRate(Currency currency)
            {
                Clients.All.updateCurrencyRate(currency);
            }
        }
    
        public enum MarketState
        {
            Closed,
            Open
        }
    
        #endregion
    }
