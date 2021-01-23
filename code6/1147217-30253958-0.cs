    for (int i = 0; i < count; i++)
    {
         string test = "txtC" + i + "Name";
         Control myControl = this.FindControl(test);
         TextBox txt = (TextBox)myControl;
         if(myControl !=null)
         {
               if (validate.isEmpty(txt.Text) == true)
               {
                  x = "LOL";
               }
         }   
    }
     
