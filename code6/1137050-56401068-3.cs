    SignalR self-hosting:
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using Microsoft.Owin;
    using SignalrDomain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SignalRBroadcastServiceSample
    {
        public class CurrencyExchangeHub : Hub
        {
            private readonly CurrencyExchangeService _currencyExchangeHub;
    
            public CurrencyExchangeHub() :
                this(CurrencyExchangeService.Instance)
            {
    
            }
    
            public CurrencyExchangeHub(CurrencyExchangeService currencyExchange)
            {
                _currencyExchangeHub = currencyExchange;
            }
    
            public IEnumerable<Currency> GetAllCurrencies()
            {
                return _currencyExchangeHub.GetAllCurrencies();
            }
    
            public string GetMarketState()
            {
                return _currencyExchangeHub.MarketState.ToString();
            }
    
            public bool OpenMarket()
            {
                _currencyExchangeHub.OpenMarket();
                return true;
            }
    
            public bool CloseMarket()
            {
                _currencyExchangeHub.CloseMarket();
                return true;
            }
    
            public bool Reset()
            {
                _currencyExchangeHub.Reset();
                return true;
            }
        }
    }
