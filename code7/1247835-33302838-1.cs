    // Using the extension namespace
    using Project.DateTimeExtensions;
    public class MyClass()
    {
        public IDataService DataService;
        public MyClass(IDataService dataService)
        {
             this.DataService = dataService
        }
        public void MyMethod()
        {
            // Get the date time value however you would normally
            var vb6DateTime = this.DataService.GetDate();
            // Convert the value using the extension method
            var convertedDateTime = vb6DateTime.FromVb6DateTime();
        }
    }
