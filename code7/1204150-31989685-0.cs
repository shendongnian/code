    public class PersonModel
    {
        string firstName;
        string Surname;
        DateTime DateOfBirth
    }
    public class PersonDisplayViewModel
    {
        PersonModel Model;
        string FullName
        {
            get{return Model.firstname + " " + Model.Surname;}
        }
        int Age
        {
            get{return (DateTime.Today() - Model.DateOfBirth).TotalYears;}
        }
    }
    public class PersonEditViewModel
    {
        PersonModel Model;
        string FirstName {
            get{return Model.FirstName;}
            set{Model.FirstName = value;}
        }
        string Surname{
            get{return Model.Surname;}
            set{Model.Surname= value;}
        }
        DateTime DateOfBirth{
            get{return Model.DateOfBirth;}
            set{Model.Surname= DateOfBirth;}
        }
    }
