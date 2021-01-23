    public class Foo 
    {
        public void MethodBah()
        {
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
            MethodBase callingMethod = t.GetFrame(1).GetMethod();
            Type callingMethodType = callingMethod.DeclaringType;
            string className = callingMethodType.Name;
        }
    }
