    public void SaveMetadata(object param) //i can see on debugging that i have all the fields thati have saved in form 
    { 
        ObservableCollection<ButtonProgram> newCollection = new 
        ObservableCollection<ButtonProgram>(programs.ToList()); 
        ButtonProgram p1 = new ButtonProgram(); 
        p1.Name = Name; 
        p1.Author = Author; 
        p1.Company = Company; 
        p1.Description = Description; 
        p1.DateCreation = DateCreation; 
        newCollection.Add(p1); 
        Programs = newCollection;
    }
