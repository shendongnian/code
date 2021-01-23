    class form1
    {
    	public ObservableCollection<string> MyList{ get; }= new ObservableCollection<string>();
        public form1()
        {
            MyList.CollectionChanged += onCollectionChanged ;
            form2.MyList = MyList;
            form2.Initialise();
        }
    
        private void onCollectionChanged (object sender,CollectionChangedEventArg args)
        {
             //update control on form1
        }
        private void AddItemToList(string item)
        {
             MyList.Add(item);
             //this will then raise a CollectionChanged event in both form1 and 2 (and anything else that is listerning to the event) allowing both to automatically add the new item in the control on themselves
        }
    }
    class form2
    {
    	public ObservableCollection<string> MyList{ get; set; }
        public void Initialise()
        {
            MyList.CollectionChanged += onCollectionChanged ;
        }
    
        private void onCollectionChanged (object sender,CollectionChangedEventArg args)
        {
             //update control on form2
        }
    }
