    using System.Collections.Generic;
    public class Main {
    
       public List<Mark> MarkList = new List<Mark>()
    
       public void Main() {
          // do stuff to get the needed variables
          MarkList.Add(new Mark(ControllerObject, GetControllerPosition(), GetControllerRotation()));
       }
    }
