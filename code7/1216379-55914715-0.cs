    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                int rows=5;
                for(int i=1;i<=rows;i++){
                    for(int j=1;j<=i;j++){
                        Console.Write(" "+j);
                    }
                    for(int k=i-1;k>=1;k--){
                        Console.Write(" "+k);
                    }
                     Console.WriteLine();
                }
            }
        }
    }
