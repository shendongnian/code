    using System;
    using Moq;
    using NUnit.Framework;
    
    namespace Tests
    {
        [TestFixture]
        class Tests
        {
            [Test]
            public void Throws()
            {
                var sender = new Mock<object>();
                var args = new Mock<EventArgs>();
    
                Assert.Throws<IndexOutOfRangeException>(() => button1_Click(sender.Object, args.Object));
            }
    
            public void button1_Click(object sender, EventArgs e)
            {
                double[] dummy = new double[1];
                int i = 1;
    
                if (i > 0)
                {
    
                    throw new System.IndexOutOfRangeException("index parameter is out of range.");
                }
                else
                {
                    dummy[i] = 6;
                }
    
            }
        }
    }
