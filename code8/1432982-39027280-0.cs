        [TestMethod]
        public void ObjectToInt()
        {
            object a = 2;
            object b = "3";
            int aa = (int)a;
            int bb = (int)b; // this throws the same error
            var x = 1;
        }
