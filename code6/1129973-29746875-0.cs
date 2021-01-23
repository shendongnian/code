    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace UnitTestProject2
    {
        class A 
        {
        }
    
        class B : A
        {
        }
    
        class C : B
        {
        }
    
        class D : E
        {
        }
    
        class E : J
        {
        }
    
        class I 
        {
        }
    
        class J : I
        {
        }
        [TestClass]
        public class test
        {
            [TestMethod]
            public void t()
            {
                B b = new B();
    
                A a = new A();
                A c = new C();
    
                I i = new I();
                I k = (I)new D();
    
                J d = (J)new D();
                J j = (J)new E();
             
    
                Assert.IsTrue(c is B); //this should be true
    
                Assert.IsFalse(i is J); //this should be false
    
                Assert.IsTrue(b is A); //this should be true
    
                Assert.IsFalse(d is A); //this should be false
    
                Assert.IsTrue(d is E); //this should be true
                Assert.IsTrue(k is E); //this should be true
    
                Assert.IsFalse(c is I); //this should be false
            }
        }
    }
