    using System;
    using System.Collections.Generic;
    
    public class Test{
    	static void Main(string[] args){
            string s = " *****.********* start *****.********* aaaaaaaaaaaaaaa adddddddddddddddd dddddddddddddd end *****.********* start *****.********* frfrffrfrffr bbbbbbbbbbbbbbb gggggggggggggggg end *****.********* start *****.********* ppppppppppwpw hhhhheeehheee mmmmmmmmmmeem end ";
            List<String> values = new List<String>();
            while (s.Contains("start") && s.Contains("end")){
                string g = s;
                values.Add(g.Substring((g.IndexOf("start") + "start".Length), (g.IndexOf("end") - g.IndexOf("start") - "start".Length)));
                s = s.Substring(s.IndexOf("end")+ "end".Length);
            }
            foreach (string v in values){
                Console.WriteLine(v);
            }
            Console.ReadKey();
        }
    }
