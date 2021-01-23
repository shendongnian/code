    			//chk = CheckBox object
				//item = the object in my model on the Window/User control datacontext
				//IsChecked = name of the property inside item that I bind to the checkbox
				Binding myBinding = new Binding("IsChecked");
				myBinding.Source = item;
				
				//If your property should be not a boolean you can set a converter
				//In this sample I have a String to boolean converter if needed
				//myBinding.Converter = new StringToBoolConverter();
				//Set the binding mode, oneway, twoway or whatever
				myBinding.Mode = BindingMode.TwoWay;
				//Indicate to the binding that the Property Change is triggering and update
				myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
				
				//Set the binding in the Checkbox object on my window
				chk.SetBinding(CheckBox.IsCheckedProperty, myBinding);
