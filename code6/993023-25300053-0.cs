     public SortingExampleViewModel()
            {
                ObservableCollection<items> myData = new ObservableCollection<items>()
                {
                    new items(){firstName = "Vijay Dhas",age=27},
                    new items(){firstName = "Ramaraj",age=28},
                    new items(){firstName = "Arun",age=29},
                    new items(){firstName = "Prabhu",age=30},
                    new items(){firstName = "Pranesh",age=31},
                    new items(){firstName = "Testing",age=32}
                };
    
                
                sordtedList = new ObservableCollection<items>(from i in myData orderby i.firstName select i);
                temp = sordtedList;       
    
                var canConfirm = this.WhenAny(x => x.SearchText, (search) => SearchMethod(search.Value));
                ExecuteSearch = new ReactiveAsyncCommand(canConfirm, 0);
            }
    
     public Boolean SearchMethod(String searchValue)
            {
                ObservableCollection<items>  tempList = new ObservableCollection<items>();            
                tempList = temp;
                tempSordtedList = new ObservableCollection<items>();
                foreach (items items in tempList)
                {
                    if (items.firstName.ToLower().StartsWith(searchValue.ToLower()))
                    {
                        tempSordtedList.Add(items);
                    }
                }
    
                sordtedList = tempSordtedList;
                return true;
            }
