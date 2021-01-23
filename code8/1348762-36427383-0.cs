    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace stringi
    {
        class Program
        {
            static void Main(string[] args)
            {
                //this is your original string
                string s = "user:jim;id:23;group:49st";
                //string with replace characters
                string s2 = "76pm";
    
                //convert string to char array so you can rewrite character
                char[] c = s.ToCharArray(0, s.Length);
    
                //asign characters to right place
                c[21] = s2[0];
                c[22] = s2[1];
                c[23] = s2[2];
                c[24] = s2[3];
    
                //this is your new string
                string new_s = new string(c);
    
                //output your new string
                Console.WriteLine(new_s);
    
                Console.ReadLine();
            }
        }
    }
