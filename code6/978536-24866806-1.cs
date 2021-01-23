		Define Global `ObservableCollection<Data> obj;`
				
        protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			obj = new ObservableCollection<Data>();
			obj.Add(new Data("string1"));
			obj.Add(new Data("string2"));
			obj.Add(new Data("string3"));
			obj.Add(new Data("string4"));
			lst.ItemsSource = obj;
		}
		
        //For adding new values to the list, must be seen in the listbox
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			obj.Add(new Data("New Item"));
		}
    public class Data
    		{
    			public string Str { get; set; }
    
    			public Data() { }
    
    			public Data(string Str)
    			{
    				this.Str = Str;
    			}
    		}
