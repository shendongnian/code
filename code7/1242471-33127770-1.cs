    interface IPerson
    {
        string Title {get; set;}
        string Name {get; set;}
        int DoB {get; set;}
        int Age {get; set;}
    }
    
    interface IDetails : IPerson
    {
        int Religion {get; set;}
        int NationalInsuranceNumber {get; set;}
    }
