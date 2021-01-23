    namespace xyz {
	public partial class FileLineDropBox : UserControl {
		...
		//Changing ComboBox/////////////////////////////////////////////////////
		public void CB_Add_Item(string NewItem) {
			this.FileLineCB.Items.Add(NewItem);
		}
		public void CB_Select_Item(string SelectThis) {
			this.FileLineCB.SelectedItem = SelectThis;
		}
		//Value/////////////////////////////////////////////////////////////////
		public string Value{
			get { return (string)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}
	    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(FileLineDropBox), new UIPropertyMetadata(""));
		////////////////////////////////////////////////////////////////////////
		// Eventhandler (Text / Selection changed)
		private void valueChangedEventHandler(object sender, RoutedEventArgs e){
			RaiseEvent(new RoutedEventArgs(FileLineDropBox.ValueChangedEvent));
		}
		////////////////////////////////////////////////////////////////////////
		// Routing the EventHandler up to the MainWindow
		public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChangedEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileLineDropBox));
		public event RoutedEventHandler ValueChanged{
			add { AddHandler(ValueChangedEvent, value); }
			remove { RemoveHandler(ValueChangedEvent, value); }
		}
	}
