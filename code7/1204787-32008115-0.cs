    public class Adder
    {
        public int Result {get; private set;}   // private setter allow you to hide this member.
    
        public void Sum(int value1, int value2)
        {
            Result = value1 + value2;
        } 
    }
