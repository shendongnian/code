        public static void TestMethod<T>(this T context, ModelStateDictionary modelsState) where T : YourDbBaseClass
        {
            //check context
            //add errors if exist
            modelsState.AddModelError("Error", "Big Error");
        }
        //Usage
        TestMethod<YourDbContext>(ModelState);
