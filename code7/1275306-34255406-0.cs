    class SomeJob {
        myDependency _param1;
        public SomeJob(myDependency param1) {
            _param1 = param1;
        }
        void ExecuteTask() {
            _param1.DoStuff();
        }
    }
