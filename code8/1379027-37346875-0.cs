       public class Form1 {
         ...
         public static IEnumerable<Control> AllControls(Control control) {
          var controls = control.Controls
            .OfType<Control>();
    
          return controls
            .SelectMany(ctrl => AllControls(ctrl))
            .Concat(controls);
         }
    
         public String AllToppings {
           get {
             var source = AllControls(this) 
               .OfType<CheckBox>()
               .Where(checkbox => checkbox.Checked)
               //TODO: put other conditions on checkbox here, e.g. 
               //.Where(checkbox => checkbox.Name.Contains("Tick")) 
               .Select(checkbox => checkbox.Text); 
              
             return String.Join(" ", source);
           }  
         } 
         ...
     
       }
