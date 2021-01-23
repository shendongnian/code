    public class A
    {
        public virtual string Y()
        {
            return Log.GetMethodName();
        }
    }
    public class B : A {
        public override string Y()
        {
            return Log.GetMethodName();
        }
    }
        
    public class Log
    {
        public static string GetMethodName()
        {
        var st = new StackTrace();
        var sf = st.GetFrame(1);
        var method = sf.GetMethod();
            return method.DeclaringType.Name +"."+ method.Name;
        }
    }
