				if (btn.Name == ("Butt" + i))
				{
					btn.Content = "works";
					MyData mydata = new MyData();
					var oBind = new Binding
					{
						// bind its source to this view model instance
						Source = mydata,
						// what property on THE BUTTON do want to be bound to.
						Path = new PropertyPath("Color")
					};
					btn.SetBinding(BackgroundProperty, oBind);
					btn.DataContext = oBind;
					break;
				}
