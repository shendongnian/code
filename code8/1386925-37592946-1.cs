    namespace freesongsforme
    {
    
      public class MyClass {
    
        static void Main(string[] args)
        { 
          var listView = new ListView();
          var myTrainers = new ObservableCollection<string>() { 
    
            "Song 1",
            "Song 2",
    
          };
    
        listView.ItemsSource = mySongs; 
    
        myTrainers.Add("Songsr");
    
      }
    }
