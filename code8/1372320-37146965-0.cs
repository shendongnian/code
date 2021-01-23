    string _genderCategory;
    public string GenderCategory
    {
        get
        {
            return _genderCategory ?? GenderList.FirstOrDefault();
        }
        set
        {
            if (value.Equals("Female"))
                Model.SetGender(Constants.Category.Female, Person.Age);
            else
            {
                Model.SetGender(Constants.Category.Male, Person.Age);
            }
            RaisePropertyChanged(() => Gender);
    
            _genderCategory = value;
        }
    }
