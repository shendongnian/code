    void Main()
    {	
    	var result = Detail.Create();
    	
    	var final = result.GroupBy(s=>s.agent).Select(a=>new 
    												{ 
    												a.OrderBy(n=>n.dateTime).Last().id,
    												a.OrderBy(n=>n.dateTime).Last().prop,
    												a.OrderBy(n=>n.dateTime).Last().dateTime,
    												a.OrderBy(n=>n.dateTime).Last().price,
    												agent = a.Key
    												});
    	
    	
    	foreach(var x in final)
    	{
    	  Console.WriteLine(x.id + " :: " + x.prop + " :: " + x.dateTime+ " :: " + x.price+ " :: " +x.agent);
    	}
    }
    
    public class Detail
    {
     public Detail(int i, string p, DateTime d, int pr, string a)
     {
       id= i;
       prop = p;
       dateTime = d;
       price = pr;
       agent = a;
     }
      public int id;
      public string prop;
      public DateTime dateTime;
      public int price;
      public string agent;
      
      public static  List<Detail> Create()
      {
    	List<Detail> list = new List<Detail>();
    	
    	list.Add(new Detail(1, "xxxxxx", DateTime.Parse("17-06-2015"), 10000,"abc"));
    	list.Add(new Detail(2, "xxyyyyy", DateTime.Parse("15-06-2015"), 10000,"abc"));
    	list.Add(new Detail(3, "xxyyyyy", DateTime.Parse("16-06-2015"), 10000,"bcd"));
    	list.Add(new Detail(4, "xxyyyyy", DateTime.Parse("15-06-2015"), 10000,"bcd"));
    	list.Add(new Detail(5, "xxyyyyy", DateTime.Parse("17-06-2015"), 10000,"cde"));
    	list.Add(new Detail(6, "xxyyyyy", DateTime.Parse("15-06-2015"), 10000,"cde"));
    	
    	return list;
       }
    }
