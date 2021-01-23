        public bool MyServiceMethod(int serviceParam)
        {
            MyBusinessManager dvqBusinessManager = MyBusinessManager.GetInstance();
            MyServiceTestableMethod(dvqBusinessManager, serviceParam);
        }
        public bool MyServiceTestableMethod(MyBusinessManager manager, int serviceParam)
        {
            return manager.MyBusinessManagerMethod(serviceParam);
        }
 
