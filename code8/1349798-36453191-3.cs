    public class MyCustomException : Exception
    {
        public MyCustomException(string msg) : base(msg)
        {
        }
    }
    public byte[] AnyMethod()
    {
        try
        {
            return GetBytes(); // exception possible
        }
        catch (Exception e)
        {
            string errorMessage = "Some custom message, which should the caller of that method should receive";
            throw new MyCustomException(errorMessage);
        }
    }
