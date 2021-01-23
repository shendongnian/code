    Database Table {FirstName, Surname, DOB}
    
    DataModel
    {
        String firstname;
        String Surname;
        dateTime DOB;
        static DataModel Load(string name){}//read from DB
        static DataModel Load(dateTime dob){}//read from DB
        void Save(){}//write to DB
    }
    
    BusinessModel
    {
        DataModel orginalData
        String FullName;
        int Age;
        bool IsValid;//validate changes ie that age as less than 100 
        void Reset(){}//undo changes and reset data to orginalData
        string ValidateText(){}//Text explaining why is valid is false
        void Save(){}//copy changes to DataModel and ask it to save to DB
        //Events to inform GUI of data changes that need refreshing
    }
