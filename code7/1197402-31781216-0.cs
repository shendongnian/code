    public class TestFunc
    {
        public Func<int, Boolean>[] Filters;
        public int[] Values;
        public void Test()
        {
            Filters = new Func<int, bool>[] { Filter1, Filter1, Filter3 };
            Values = new int[] { 1, 2, 3 };
    
            var result = Filters[0].Invoke(Values[0]);
        }
        Boolean Filter1(int a)
        {
            return a > 0;
        }
        Boolean Filter2(int a)
        {
            return a % 2 == 0;
        }
        Boolean Filter3(int a)
        {
            return a != 0;
        }
    
    }
