        foreach (object tmp in textBoxCollection)
        {
            
            if(tmp  is MyTextBox) {
               MyTextBox mtb = (MyTextBox )tmp;
               int number
               bool mybool = Int32.TryParse(mtb.Text, out number);
               if (mybool == false)
               {
                  //some operation
               }
               else
               {
                  //some other operation
               }
            }
         } 
