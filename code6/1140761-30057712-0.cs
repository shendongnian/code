            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
        
            namespace Student
            {
                public interface IMyClick
                {
                    string click();
                }
            }
        --------------------------
        
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;
            
            namespace Student
            {
              public  class Middle : IMyClick
                {
            
                    public string click()
                    {
                        return "Middle Click";
                    }
                }
            }
    
        ---------------------------
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace Student
        {
         public class End :IMyClick
            {
                public string click()
                {
                    return "End Click";
                }
            }
        }
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Student;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                IMyClick m1 = new Middle();
    
                IMyClick e1 = new End();
    
                string result = MethodtoGo(m1);
                Console.WriteLine(result);
                Console.Read();
    
            }
    
            static string MethodtoGo(IMyClick cc)
            {
                 return cc.click();
            }
        }
    }
