    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Timers;
    namespace Tdo
    {
        class Program
        {
          public static bool k=true;
            static void Main(string[] args)
            {
                Timer q = new Timer(2000);
                q.Elapsed += Q_Elapsed;
                q.Start();
                while(k)
                {
                    Console.WriteLine(DateTime.Now);
                }
                Console.ReadKey();
            }
    
            private static void Q_Elapsed(object sender, ElapsedEventArgs e)
            {
                StopTheCode(ref k);
            }
    
            public static void StopTheCode(ref  bool flag)
            {
                flag= false;   
            }            
            
        }
    }
