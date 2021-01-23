     class TestViewModel : BindableBase  
        {  
            private TestModel testModel;  
      
            public ICommand AddCommand { get; private set; }  
            public TestViewModel(StackPanel stkpnlDynamicControls)  
            {  
                testModel = new TestModel();  
                TestModel.stkPanel = stkpnlDynamicControls;  
                AddCommand = new DelegateCommand(AddMethod);  
            }  
            public TestModel TestModel  
            {  
                get { return testModel; }  
                set { SetProperty(ref testModel, value); }  
            }  
            private void AddMethod()  
            {  
                Label lblDynamic = new Label()  
                {  
                    Content = "This is Dynamic Label"  
                };  
                TestModel.stkPanel.Children.Add(lblDynamic);  
            }  
        }
