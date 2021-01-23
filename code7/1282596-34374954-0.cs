    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static AutoResetEvent autoEvent = new AutoResetEvent(false);
            const string FILENAME = @"c:\temp\test.xml";
            private static void Main(string[] args)
            {
                State state = new State();
                state.l  = new List<int>() { 1, 2, 3, 4, 5, 6 };
                state.index = 0;
                state.xdoc = XDocument.Load(FILENAME);
                state.num = state.xdoc.Descendants("num").FirstOrDefault();
                state.xdoc.Descendants("max").FirstOrDefault().Value = state.l.LastOrDefault().ToString();
                Timer t = new Timer(printnum, state, 0, 5000);
                autoEvent.WaitOne();
                t.Dispose();
            }
            public class State
            {
                public XElement num { get; set; }
                public XDocument xdoc { get; set; }
                public List<int> l { get; set; }
                public int max { get; set; }
                public int index { get; set; }
            }
            public static void printnum(Object o)
            {
                State state = o as State;
                try
                {
                    int num = state.l[state.index++];
                    Console.WriteLine(num);
                    state.num.Value = num.ToString();
                    state.xdoc.Save(FILENAME);
                    if (state.index >= state.l.Count)
                    {
                        autoEvent.Set();
                    }
                }
                catch (Exception e)
                {
                }
            }
        }
    }
    ​
