     private ObservableCollection<Data> myData = null;
        public ObservableCollection<Data> MyData
        {
            get
            {
                if (myData == null)
                    myData = new ObservableCollection<Data>();
                if (myData != null)
                {
                    myData = new ObservableCollection<MyClass>(myData.Where(x => !string.IsNullOrEmpty(x.Name)));
                    //If Class Data has property Name
                    //Additional consitions also can be added in where clause
                }
                return myData;
            }
        }
