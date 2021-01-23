    public class Item {
       public string Name { get;set;}
       public List<PriceList> Prices {get;set;} = new List<PriceList>();
    }
    public string[] stringItems = {"sItem1", "sItem2", "sItem3"};
    var items=stringItems.Select(x=>new Item {Name=x});
    -- Adding --
    items.First(i=>i.Name=="sItems1").Prices.Add(new PriceList() { ... });
