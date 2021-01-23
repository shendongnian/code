        public void InvokeGenericType()
        {
            // comment out the two lines below to make the code fail
            var strClass = new SomeGenericClass<string>();
            strClass.Execute("Test");
            var type = typeof(SomeGenericClass<>).MakeGenericType (typeof(string));
            var instance = Activator.CreateInstance (type);
            var method = type.GetMethod ("Execute");
            method.Invoke (instance, new object[]{"Test"});
        }
