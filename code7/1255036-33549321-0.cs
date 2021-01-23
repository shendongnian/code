       [TestMethod]
        public void Test_Clean_Price()
        {
            Mock<CalcProcessor> calcProcessor = new Mock<CalcProcessor>();
            calcProcessor.Setup(s => s.AddProcessor(It.IsAny<int>(), It.IsAny<int>())).Returns(1);
            Mock<Calc> calc = new Mock<Calc>(calcProcessor.Object);//this should not a mock object
            ICalc icalc = calc.Object;
            int resultObject = calc.Object.Add(1, 2);
            int resultInterface = icalc.Add(1, 2);
            Assert.AreEqual(1,resultObject);//result 0
            Assert.AreEqual(1, resultInterface);//result 0
        }
    }
    public class CalcProcessor
    {
        public virtual int AddProcessor(int a, int b)
        {
            return a + b;
        }
    }
    public class Calc : ICalc
    {
        private CalcProcessor cp;
       
        public Calc(CalcProcessor calcp)
        {
            this.cp = calcp;
        }
        public virtual int Add(int a, int b)
        {
            return this.cp.AddProcessor(a,b);
        }
        public virtual int Substract(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
    public interface ICalc
    {
        int Add(int a, int b);
        int Substract(int a, int b);
    }
