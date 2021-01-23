    class ViewModel
	{
		MyModel model;
		ObservableCollection<MyClass> MyFirstList {	get; set; }
		ObservableCollection<MyClass> MySecondList	{	get; set;	}
		ObservableCollection<MyClass> MyThirdList { get; set; }		
        public ViewModel(MyModel model) {
             this.model = model;
             RefreshCollections();
        }
        public void RefreshCollections() {
             //Clear the observable collections.
             MyFirstList.Clear();
             foreach(var item in model.MyUnifiedList) {
                  //TODO: add to the correct collection based on criteria.
             }
        }
	}
