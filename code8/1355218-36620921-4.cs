    public static class SomethingExtension
    {
        public static Something Populate(this Something someObj, Action<Something> actionToPopulate)
        {
            actionToPopulate.Invoke(someObj);
            return someObj;
        }
    }
