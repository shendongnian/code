     public class ArrayData
    {
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public int EmployeeNumber { get; set; }
        public ArrayData(string FirstName, string LastName, int EmployeeNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.EmployeeNumber = EmployeeNumber;
        }
    }
       protected override void OnNavigatedTo(NavigationEventArgs e)
        {      
            var data = new ArrayData[]
           {
               new ArrayData("Fistname1","LastName1",1),
               new ArrayData("Fistname2","LastName2",2),
               new ArrayData("Fistname3","LastName3",3),
               new ArrayData("Fistname4","LastName4",4),
           };
            lstbx.ItemsSource = data;
        }
    
