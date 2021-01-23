    class MakeEverythingStrictOptionsBuilder: IFakeOptionsBuilder
    {
        public bool CanBuildOptionsForFakeOfType(Type type)
        {
            return true;
        }
    
        public void BuildOptions(Type typeOfFake, IFakeOptions options);
        {
            options.Strict();
        }
    
        public int Priority
        {
            get { Priority.Default; }
        }
    }
