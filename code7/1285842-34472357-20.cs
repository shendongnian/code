    public MainWindow()
    {
        InitializeComponent();
        PopulatePeople();
    }
    private void PopulatePeople()
    {
       List<Person> persons = new List<Person>();
       for (int i = 0; i < 10; i++)
       {
          persons.Add(new Person() { Name = "Bob " + i.ToString(), ImageAddress = "Images/peach.jpg" });
        }
       listBox.ItemsSource = persons;
     }
