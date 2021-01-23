      MyCheckbox[] path1 = {
                new MyCheckbox() { FilePath = "Fine.txt", IsEnabled = false },
                new MyCheckbox() { FilePath = "Debug.txt", IsEnabled = true },
                new MyCheckbox() { FilePath = "Info.txt", IsEnabled = true } };
                    
            public MyCheckbox[] MyCheckBockes
            {
                get { return path1; }
                set
                {
                    path1 = value;
                    OnPropertyChange("MyCheckBockes");
                }
            }
