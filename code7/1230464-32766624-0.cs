    public Data()
            {
                NameList = new ObservableCollection<string>();
                NameList.Add("Loading");
    
                UpdateAysnc(results => SetList(results));
    
            }
            public void SetList(object param)
            {
                NameList = TempList;
            }
            public void UpdateAysnc(Action<ObservableCollection<string>> onUpdateComplete)
            {
                var tempList = new ObservableCollection<string>();
                System.Threading.Thread.Sleep(10000);
                for (int i=0;i<10;i++)
                {
                    tempList.Add(i.ToString());
                }
       
                onUpdateComplete(tempList);
            }
