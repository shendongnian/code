    //model
    class DummyModel{
    	public int Id{get;set;}
    	public string Value{get;set;}
    }
    //view-model
    class DemoVM:INotifyPropertyChanged{
        private int selId;
        //you can build the list any way you want (even with hardcoded values...)
    	public List<DummyModel> Items{get{return new List<DummyModel>();}}
    	public int SelectedId{
    		get{return selId;}
    		set{
    			if(selId==value)return;
    			selId=value;
    			RaisePropertyChanged("SelectedId");
    		}
    	}
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected void RaisePropertyChanged(string name){
    		//raise event here
    	}
    }
    //view
    <ComboBox ItemsSource="{Binding Items}" 
    	SelectedValue="{Binding SelectedId}"
    	SelectedValuePath="Id" IsTextSearchEnabled="True" IsTextSearchCaseSensitive="False"
    	IsEditable="True" TextSearch.TextPath="Value">
    	<ComboBox.ItemTemplate>
    		<DataTemplate>
    			<TextBlock Text="{Binding Value}"/>
    		</DataTemplate>
    	</ComboBox.ItemTemplate>
    </ComboBox>
