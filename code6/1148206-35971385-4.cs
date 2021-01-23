    public class ViewModel : INotifyPropertyChanged
    {
       protected Model model {get;} //C# 5 assumed..
       public ViewModel() //parameterless c-tor used for mock for the view.
       {
           model = new Model();
       } 
       public ViewModel(Model model)
       {
          this.model = model;
       }
       
       public string SomeProperty
       {
         get { return Model.SomeProperty; } 
         set
         { 
           Model.SomeProperty = value; 
           PropertyChanged?.Invoke(this, new PropertyChangedEventsArgs(this, "SomeProperty"));
         }
       }
    }
