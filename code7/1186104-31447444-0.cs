    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    namespace Test
    {
       
        public class SPLimitedWebPartManager : IDisposable
        {
            public void Dispose() { 	                 }        
            internal void AddWebPart(WebPart wp,string p1,int p2) { }
        }
        public class WebPart
        {
            public object ChromeType { get; set;  }
        }
        public class WebPart1 : WebPart {}
        public class WebPart2 : WebPart {}
        internal class Program
        {
           public void AddWebPart( WebPart w)
           {
                 using (SPLimitedWebPartManager wpMngr = new SPLimitedWebPartManager() )
                 {
                      var wp = w;
                      wp.ChromeType = "stuff";
                      wpMngr.AddWebPart(wp, "left", 0);
                 }
            }
            private static void Main(string[] args)
            {
                Program p = new Program();
                p.AddWebPart( new WebPart1() );
                p.AddWebPart( new WebPart2() );
            }
        }
    }
