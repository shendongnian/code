    public class a
    {
        public virtual string y()
        {
            return log.getMethodName();
        }
    }
    public class b : a {
        public override string y()
        {
                return log.getMethodName();
        }
    }
        
    public class log
    {
        public static string getMethodName()
        {
        var st = new StackTrace();
        var sf = st.GetFrame(1);
        var method = sf.GetMethod();
            return method.DeclaringType.Name +"."+ method.Name;
        }
    }
