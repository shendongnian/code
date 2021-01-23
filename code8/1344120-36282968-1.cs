    public class TestList : List<Test>
    {
       public TestList ()
       {
       }
    
       public TestList (IEnumerable<Test> items)
            : base(items)
       {
       }
    }
    
    tests = new TestList(tests.OrderBy(o => o.No));
