    dynamic itemObject; //Now you can declare the variable which will accept any constructor
    public void LoadGridview(string Moder)
    {
        if (Moder == "Persons")
        {
            itemObject = PersonsMgr();
        }
        else if (Moder == "Car")
        {
            itemObject = CarsMgr();
        }
    }
