    public class Order: INotifyPropertyChanged
    {   
	    public Order()
	    {
		   ItemsA = new ChildOberservableCollection<Item>();
		   ItemsA.parent = this;
		   ...
	    }
        public DateTime OrderDate {get; set;}  
        public ChildObservableCollection<Item> ItemsA {get; set;}
        public ChildObservableCollection<Item> ItemsB {get; set;}
        public ChildObservableCollection<Item> ItemsC {get; set;}
    } 
