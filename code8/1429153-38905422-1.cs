    public class Test
    {
        public virtual IEnumerable<int> GetList(Type type, string key)
        {
		   throw new NotImplementedException();
        }
    }
    public class Test2 : Test
    {
        public override IEnumerable<int> GetList(Type type, string key)
        {
	       for (var x = 0; x <= 5; x++)
           {
               yield return x;
           }
        }
    }
    static void Main(string[] args)
    {
        var x = new Test2();
        var y = x.GetList(typeof(decimal), "test").ToList();
    }
