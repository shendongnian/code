        MyBusinessManager dvqBusinessManager = MyBusinessManager.GetInstance();
        public bool MyServiceMethod(int serviceParam)
        {
            return dvqBusinessManager.MyBusinessManagerMethod(serviceParam); // make fake service call
        }
