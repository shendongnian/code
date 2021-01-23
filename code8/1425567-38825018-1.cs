    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            peopleList.Add(new Person { Name = "Jay", Company = "AA", Age = 25 });
            peopleList.Add(new Person { Name = "Peter", Company = "BB", Age = 35 });
            peopleList.Add(new Person { Name = "Jayden", Company = "AA", Age = 27 });
            peopleList.Add(new Person { Name = "John", Company = "AAC", Age = 26 });
            peopleList.Add(new Person { Name = "Alan", Company = "BB", Age = 45 });
            peopleList.Add(new Person { Name = "Frank", Company = "BB", Age = 29 });
            peopleList.Add(new Person { Name = "Ami", Company = "AA", Age = 24 });
            peopleList.Add(new Person { Name = "Elvis", Company = "AA", Age = 30 });
            peopleCollection.Clear();
            foreach (var person in peopleList)
            {
                peopleCollection.Add(person);
            }
        }
    
        private static List<Person> peopleList = new List<Person>();
    
        public ObservableCollection<Person> peopleCollection = new ObservableCollection<Person>();
    
        public void Age_Filter(object sender, RoutedEventArgs e)
        {
            foreach (var person in peopleList)
            {
                if (person.Age > 29 || person.Age < 20)
                    peopleCollection.Remove(person);
            }
        }
    
        public void Company_Filter(object sender, RoutedEventArgs e)
        {
            foreach (var person in peopleList)
            {
                if (person.Company != "AA")
                    peopleCollection.Remove(person);
            }
        }
    
        public void Name_Filter(object sender, RoutedEventArgs e)
        {
            foreach (var person in peopleList)
            {
                if (person.Name != "Peter")
                    peopleCollection.Remove(person);
            }
        }
    
        public void Show_All(object sender, RoutedEventArgs e)
        {
            peopleCollection.Clear();
            foreach (var person in peopleList)
            {
                peopleCollection.Add(person);
            }
        }
    }
