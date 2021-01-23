        public class myClass
        {
           public string A { get; set; }
           public string B{ get; set; }
           public myClass()
           {
             //default constructor
           }
           public myClass(string S)
           {
             string[] values = S.Split(',');
             if (values.Length>=2)
             {
                this.A=values[0];
                this.B=values[1];
             }
           }
         }
