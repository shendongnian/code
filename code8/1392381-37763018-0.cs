    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> input = new List<string>() { "z", "y", "x", "w", "v", "u", "t", "s" };
                Test test = new Test();
                test.slowersort(input, 0, input.Count - 1);
     
            }
        }
     
        public class Test
        {
            public void slowersort(List<string>Value, int start, int ende)
            {
                if (start < ende)
                {
                    int middle = (start+ende)/2;
                    slowersort(Value, start, middle);
                    slowersort(Value, middle + 1, ende);
                    if (Value[middle].CompareTo(Value[ende]) == 1)
                    {
                        string temp = Value[middle];
                        Value[middle] = Value[ende];
                        Value[ende] = temp;
                    }
                    slowersort(Value, start, ende - 1);
                }
            }
        }
        
    }
