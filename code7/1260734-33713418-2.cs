    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace TestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                XCharacter x = new XCharacter() { isDead = true, Health = 100 };
                YCharacter y1 = new YCharacter() { isDead = true, Health = 100};
                YCharacter y2 = new YCharacter() { isDead = true, Health = 0 };
                Assert.AreEqual(x, y1); //ok 
                Assert.AreNotEqual(x, y2); //ok
                Assert.AreEqual(x,y2); // not ok
            }
        }
    
        public abstract class BaseCharacter
        {
            public bool isDead { get; set; }
            public int Health { get; set; }
    
            public override bool Equals(object obj)
            {
                BaseCharacter that = (BaseCharacter)obj;
                return this.isDead == that.isDead && this.Health == that.Health;
            }
        }
    
        public class XCharacter : BaseCharacter
        {
        }
    
        public class YCharacter : BaseCharacter
        {
        }
    }
