     [TestMethod()]
        public void GetMaxTest1()
        {
            int[] array = new[] { 0, 1, 2 };
            Class obj = new Class();
            List<int> output = new List<int>();
            obj.GetMaxPerm(array, 0, output, 0, 3);
        }
