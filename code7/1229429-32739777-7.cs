    Class Configuration
    {
        ...
        public Configuration(...)
        {
           ... // set up stuff
           MyObject.PropertyChanged += myObjectChanged_DoSomethingAboutIt;
        }
        private void myObjectChanged_DoSomethingAboutIt()
        {
             DoSomething();
             // for example:
             Property = MyObject.ToString();
        }
    }
