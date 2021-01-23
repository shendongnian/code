    [TestMethod]
        public void TestMethod1()
        {
            string n = "54.34.23";
            double d1;
            double d2;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            bool test = double.TryParse(n, out d1);
    
            Console.WriteLine("test : " + test);
            Console.WriteLine("d1 : " + d1);
        }
