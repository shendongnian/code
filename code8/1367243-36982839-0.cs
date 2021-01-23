    class MyViewModel {
	
	private IList<Item> instanceList= new List<Item>();
	
	public IList<Item> List
	{
		get {return list; }
		set {
			list = value;
			RaisePropertyChanged(() => List);
		}
	}
	
	private Item selectedItem;
	
	public Item SelectedItem {
		get {return selectedItem;}
		set {
			selectedItem = value;
			RaisePropertyChanged(() => SelectedItem);
		}
	}}
