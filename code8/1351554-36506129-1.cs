    void Main()
    {
        var oldFoo = new OldFoo();
        var oldResult = oldFoo.Calculate(2, 2); // 4
        var newFoo = new NewFoo();
        var newResult = newFoo.Calculate(2, 2); // 0
    }
    
    public class OldFoo
    {
        public int Calculate(params int[] values)
        {
            return values.Sum();
        }
    }
    
    public class NewFoo
    {
        public int Calculate(params int[] values)
        {
            return values.Sum();
        }
    
        public int Calculate(int value1, int value2)
        {
            return value1 - value2;
        }
    }
