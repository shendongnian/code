    public static class ThisAddInManager
    {
        struct someProperties
        {
            public string foo, bar;
        }
        
        public static var SomeProperties { private get; set; } = new someProperties();
        public static var UI { private get; set; } = new formClass();
     
        public static void OpenUI() => UI.showDialog();
        public static void RunFunction() => doSomethingWith(SomeProperties);   
    }
