    public void SaveMetadata(object param)  //i can see on debugging that i have all the fields thati have saved in form
    {            
           programs = new ObservableCollection<AddButtonViewModel>();
           AddButtonViewModel p1 = new AddButtonViewModel();
           p1.Name = Name;
           p1.Author = Author;
           p1.Company = Company;
           p1.Description = Description;
           p1.DateCreation = DateCreation;
           Programs.Add(p1);
    }
