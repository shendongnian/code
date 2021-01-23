    public class ViewModel : INotifyPropertyChanged
    {
       protected ModelType1 model1 {get;}
       protected ModelType2 model2 {get;}
       public ViewModel(){} //parameterless c-tor used for mock for the view.
       public ViewModel(ModelType1 model1, ModelType2 model2)
       {
          this.model1 = model1;
          this.model2 = model2;
       }
       
       public string SpecialProperty
       {
         get { return $"{model1.SomeProperty}.{model2.SomeOtherProperty}"; } 
         set
         { 
           var arr = value.Split('.');
           model1.SomeProperty = arr[0];
           model2.SomtOtherProperty = arr[1];
           PropertyChanged?.Invoke(this, new PropertyChangedEventsArgs(this, "SpecialProperty"));
         }
       }
    }
