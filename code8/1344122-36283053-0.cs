    public class TestList : List<Test>
    {
        public TestList()
        {
        }
    
        public TestList(IOrderedEnumerable<Test> others)
        {
            foreach (var test in others)
                Add(test);
        }
    }
