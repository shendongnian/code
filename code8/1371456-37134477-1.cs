    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Get the data
            List<MyClass> myClasses = new List<MyClass>();
            myClasses.Add(new MyClass { Name = "A", Complete = false });
            myClasses.Add(new MyClass { Name = "B", Complete = true });
            myClasses.Add(new MyClass { Name = "C", Complete = true });
            myClasses.Add(new MyClass { Name = "D", Complete = false });
            myClasses.Add(new MyClass { Name = "E", Complete = true });
            myClasses.Add(new MyClass { Name = "F", Complete = false });
            //Group the data
            var groups = from c in myClasses
                         group c by c.Complete;
            //Set the grouped data to CollectionViewSource
            this.cvs.Source = groups;
        }
    }
