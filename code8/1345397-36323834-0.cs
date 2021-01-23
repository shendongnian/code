    var list = new List<Test>();
	list.Add(new Test { Id = 1 });
	list.Add(new Test { Id = 2 });
	Expression<Func<Test, bool>> expression = x => x.Id == 1;
	
	var items = from item in list
	where expression.Compile().Invoke(item)
	select item;
	
	items.Dump();
    public class Test
    {
    	public int Id { get; set; }
    }
