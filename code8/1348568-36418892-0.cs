    // let's assume that you have a simple class:
    public class PassedData
    {
       public string Name { get; set; }
       public int Value { get; set; }
    }
    
    // then you navigate like this:
    Frame.Navigate(typeof(Page1), new PassedData { Name = "my name", Value = 10 });
    
    // and in target Page you retrive the information:
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        PassedData data = e.Parameter as PassedData;
    }
