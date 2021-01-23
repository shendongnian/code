        using System;
        using System.Collections.Generic;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        namespace UnitTestProject1
        {
            [TestClass]
            public class UnitTest1
            {
                [TestMethod]
                public void TestMethod1()
                {
                    Hammer hammer1 = new Hammer();
                    Hammer hammer2 = new Hammer();                    
                    Assert.AreEqual(2, hammer1.NumRemaining);
                    // Calling dispose doesn't set hammer1 null, just decrements the _numRemaining count
                    hammer1.Dispose();
                    Saw saw1 = new Saw();
                    Saw saw2 = new Saw();
                    var tools = new List<Tool> {hammer1, hammer2, saw1, saw2};
                    foreach (Tool tool in tools)
                    {
                        if (tool is Hammer)
                            Assert.AreEqual(1, tool.NumRemaining);
                        if (tool is Saw)
                            Assert.AreEqual(2, tool.NumRemaining);
                    }
                }
            }
            public abstract class Tool
            {
                public abstract int NumRemaining { get; }
            }
            public class Hammer : Tool, IDisposable
            {
                private static int _numRemaining;
                public Hammer()
                {
                    _numRemaining++;
                }
                public override int NumRemaining
                {
                    get { return _numRemaining; }
                }
                public void Dispose()
                {
                    _numRemaining--;
                }
            }
            public class Saw : Tool, IDisposable
            {
                private static int _numRemaining;
                public Saw()
                {
                    _numRemaining++;
                }
                public override int NumRemaining
                {
                    get { return _numRemaining; }
                }
                public void Dispose()
                {
                    _numRemaining--;
                }
            }
        }
