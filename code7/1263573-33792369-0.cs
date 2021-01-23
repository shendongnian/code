        [TestMethod]
        public void CheckFloats()
        {
            float[] array1 = new float[] { 1.0f, 2.0f, 3.0f };
            float[] array2 = new float[] { 4.0f, 5.0f, 6.0f };
            CollectionAssert.AreEqual(array1, GenerateFloats());
        }
        private float[] GenerateFloats()
        {
            return new float[] { 1.0f, 2.0f, 3.0f };
        }
