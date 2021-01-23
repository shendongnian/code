        public class OwnObject : INotifyPropertyChanged
        {
        	private string _text;
        
        	public string Text
        	{
        		get { return _text; }
        		set { _text = value; NotifyPropertyChanged( "Text" ); }
        	}
    
    ...
    
        }
    
    ...
    
        ObservableCollection<OwnObject> objects = new ObservableCollection<OwnObject>();
        objects.Add( new OwnObject() { Text = "first" } );
        objects.Add( new OwnObject() { Text = "second" } );
        objects.Add( new OwnObject() { Text = "third" } );
        icTest.ItemsSource = objects;
