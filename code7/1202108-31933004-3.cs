    public delegate int CalculateEventHandler(object obj1, object obj2);
    public class Event
    {
        static public event CalculateEventHandler Calculate;
        static public int Add(int x, int y)
        {
            int result = x + y;
            return result;
        }
        static public int OnCalculate( object obj1, object obj2 )
        {
            int result = 0;
            if( Calculate != null )
            {
                result = Calculate(obj1, obj2);
            }
            return result;
        }
    }
