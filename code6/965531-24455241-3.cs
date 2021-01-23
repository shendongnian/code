    public class Person
    {
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public int EmployeeNumber { get; set; }
        public Person(string FirstName, string LastName, int EmployeeNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.EmployeeNumber = EmployeeNumber;
        }
    }
           protected override void OnNavigatedTo(NavigationEventArgs e)
        {      
            var data = new Person[]
           {
               new Person("Fistname1","LastName1",1),
               new Person("Fistname2","LastName2",2),
               new Person("Fistname3","LastName3",3),
               new Person("Fistname4","LastName4",4),
           };
            lstbx.ItemsSource = data;
        }
    
