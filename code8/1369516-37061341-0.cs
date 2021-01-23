    public class MethodFinder
    {
        public delegate void MethodSignature();
    
        //these can live whereever and even be passed in
        private static void Method1() { Debug.WriteLine("Method1 executed"); }
        private static void Method2() { Debug.WriteLine("Method2 executed"); }
    
        //maintain an array of possibilities or soemthing.
        //perhaps use reflection instead
        public MethodSignature[] methods = new MethodSignature[] { Method1, Method2 };
    
        public MethodSignature FindByName(string methodName) 
            => (from m in methods
                where m.Method.Name == methodName
                select m).FirstOrDefault();
    }
