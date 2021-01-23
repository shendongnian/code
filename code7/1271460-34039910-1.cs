    public class A
    {
        public virtual void Do()
        {
            var lines = GetLines();
    		foreach(var line in lines)
    		    Console.WriteLine(line);
        }
    
        public virtual IEnumerable<string> GetLines()
        {
            return new string[] { "A" };
        }
    }
    
    public class B : A
    {
    
        public override IEnumerable<string> GetLines()
        {
    		var lst = new List<string>(base.GetLines());
            lst.Add("B");
    		return lst;
        }
    }
