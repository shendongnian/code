    public class CompanyInfo
    {
        public string Name { get; set; }
    
        public double Value { get; set; }
    }
    
    public class StockTrader : IObserver<CompanyInfo>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Market Closed");
        }
    
        public void OnError(Exception error)
        {
            Console.WriteLine(error);
        }
    
        public void OnNext(CompanyInfo value)
        {
            WriteStock(value);
        }
    
        private void WriteStock(CompanyInfo value) { Console.WriteLine($"{value.Name} = {value.Value}"); }
    }
    
    public class StockMarket : IObservable<CompanyInfo>
    {
    	private CompanyInfo[] _values = new CompanyInfo[]
    	{
    		new CompanyInfo() { Name = "F", Value = 1 },
    		new CompanyInfo() { Name = "S", Value = 5 },
    		new CompanyInfo() { Name = "S", Value = 4 },
    		new CompanyInfo() { Name = "F", Value = 2 },
    	};
    	
    	public IDisposable Subscribe(IObserver<CompanyInfo> observable)
    	{
    		return _values.ToObservable().ObserveOn(Scheduler.Default).Subscribe(observable);
    	}
    }
