     public class Teaching
        {       
            public void RunTests()
            {
                ObjectA a = new ObjectA();
                ObjectB b = new ObjectB();
                IContract c = new ObjectA();
                IContract d = new ObjectB();
                
                Test1(a);
                Test1(b); // Won't compile
                
                Test2(b);
                Test2(a); // Won't compile
    
                // Test3 can handle either concretion            
                Test3(c); 
                Test3(d); 
            }
    
            private void Test1(ObjectA obj)
            {
                Console.WriteLine(obj.GetExcited("Yeah"));
            }
    
            private void Test2(ObjectB obj)
            {
                Console.WriteLine(obj.GetExcited("Yeah"));
            }
    
            private void Test3(IContract obj)
            {
                Console.WriteLine(obj.GetExcited("Yeah"));
            }
    
        }
    
        public class ObjectA : IContract
        {
    
            public string GetExcited(string data)
            {
     	        return data + "!";
            }
        }
    
        public class ObjectB : IContract
        {
    
            public string GetExcited(string data)
            {
     	        return data + "!!";
            }
        }
    
        public interface IContract
        {
            string GetExcited(string data);
        }
