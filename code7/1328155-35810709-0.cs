    public List<Data> listOfData;
    
    public void AddToList()
    {
      listOfData.add(new Data {KEY_1 = "Value 1", KEY_2 = "Value 2");
      listOfData.add(new Data {KEY_1 = "Value 3", KEY_2 = "Value 3");
    
      MyListView.ItemSource = listOfData;
    }
