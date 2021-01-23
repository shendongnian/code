        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BadInput()
        {
            var expr = "1 + 5 + 2(3)";
            int value = Calculator.Evaluate(expr);
        }
