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
