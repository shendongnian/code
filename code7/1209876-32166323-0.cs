    int count = int.Parse(txtListCount.Text); //convert text in the textbox to number
    List<List<int>> myLists = new List<List<int>>(); //container for your lists
    for(int i = 0; i < count; i++)
        {
            myLists.Add(new List<int>()); //create lists dynamically
        }
    //myLists contains all your lists
