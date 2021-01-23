    interface IBase
    {
        int x;
    }
    public class C
    {
        public IBase func(IBase obj)
        {
            obj.x = 100;   
            return obj;
        }
    }
