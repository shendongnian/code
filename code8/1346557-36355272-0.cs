    public static class Worker
    {
        public static int DoWork(BaseObject obj) { return 0; }
        public static int DoWork(Derived1 obj) { return 1; }
        public static int DoWork(Derived2 obj) { return 2; }
    }
    void Execute(IEnumerable<BaseObject> list) {
        foreach (dynamic item in list) {
            Worker.DoWork(item);   // Method resolution done at run-time
        }
    }
