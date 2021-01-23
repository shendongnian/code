    [ServiceContract]
    public interface IService1
    {
    	[OperationContract]
    	IEnumerable<PriceHeader> GetData();
    }
    
    public class Service1 : IService1
    {
    	public IEnumerable<PriceHeader> GetData()
    	{
    		return PriceHeader.GetPriceHeaders();
    	}
    }
    
    public class PriceHeader
    {
        public string Desc { get; set; }
    
        public ObservableCollection<Item> Items { get; set; }
    
        public static IEnumerable<PriceHeader> GetPriceHeaders()
        {
            var list = new List<PriceHeader>
            {
                new PriceHeader(){Desc = "Desc1", Items=new ObservableCollection<Item>{new Item(){Field = "field1", Value1 = "val11", Value2 = "val21"}}},
                new PriceHeader(){Desc = "Desc2", Items=new ObservableCollection<Item>{new Item(){Field = "field2", Value1 = "val12", Value2 = "val22"}}}
            };
    
            return list;
        }
    }
