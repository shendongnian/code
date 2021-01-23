        public static void TestMethod<T>(this T value, ModelStateDictionary modelsState) where T : YourDbBaseClass
        {
            modelsState.AddModelError("Error", "Big Error");
        }
        //Usage
        TestMethod<YourDbContext>(ModelState);
