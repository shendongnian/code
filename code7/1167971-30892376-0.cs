     public static class NewtonHelpers
    {
        internal class NewtonHelper
        {
            public string test { get; set; }
        }
        public static NewtonTest BuildNewton(string jsonData)
        {
            var newtonHelper = JsonConvert.DeserializeObject<NewtonHelper>(jsonData);
            var newtonTest = new NewtonTest { test = { sample = newtonHelper.test } };
            return newtonTest;
        }
    }
