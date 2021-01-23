        public MyViewModel MyVM
        {
            get
            {
                String id = Guid.NewGuid().ToString();
                var instance = SimpleIoc.Default.GetInstance<MyViewModel>(id);
                instance.ID = id;
                return instance;
            }
        }
        
