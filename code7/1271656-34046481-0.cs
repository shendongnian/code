            void test() {
                Settings.Default.PropertyChanged += Default_PropertyChanged;
            }
    
            private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "MyProperty")
                {
                    dosomething();
                }
            }
