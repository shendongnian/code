    public class ViewModel : Model 
    {
       public ViewModel(){} //parameterless c-tor used for mock for the view.
       public ViewModel(Model model)
       {
          //Copy all model properties to view-model properties.
          //Assuming you get from "outside" a model or Data transfer object.
       } 
    }
