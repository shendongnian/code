            MyView2 objMyView2 = new MyView2();
            objMyView2.SomeProperty1 = "value1";
            objMyView2.SomeProperty2 = "value2";
            objMyView2.LaunchLocationDetailsCommand_WithParameters = new Command<object>((o2)=>
            {
                LaunchingCommands.LaunchLocationDetailsCommand_WithParameters(o2);
            });
            Grid objGrid = new Grid();
            objGrid.BindingContext = objMyView2;
            objGrid.HeightRequest = 200; 
            objGrid.BackgroundColor = Color.Red;
            TapGestureRecognizer objTapGestureRecognizer = new TapGestureRecognizer();
            objTapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, new Binding("LaunchLocationDetailsCommand_WithParameters"));
            Binding objBinding1 = new Binding()
            {
                Source = objGrid.BindingContext
            };
            objTapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, objBinding1);
            //
            objGrid.GestureRecognizers.Add(objTapGestureRecognizer);
