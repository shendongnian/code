    public class test
    {
        public static implicit operator test(test2 t)
        {
            return new test(tt.Number);
        }
    
        public static implicit operator test2(test t)
        {
            return new test2(t.Number);
        }
    
       public int Number { get; set; }
    }
