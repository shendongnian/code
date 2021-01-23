    static void Main(string[] args)
    {
        var listView = new ListView();
        var myTrainers = new ObservableCollection<string>() {
            "Trainer 1",
            "Trainer 2",
            "Trainer 3",
            "Trainer 4",
            "Trainer 5",
            "Trainer 6",
        };  
        listView.ItemsSource = myTrainers;
    
        myTrainers.Add("Trainer");
    }
