    private bool IsValidated 
    {
       get 
       {
           //Tryparse for principal amount with error shows as Red texbox
           if (String.IsNullOrEmpty(txtprincipal.Text) || !double.TryParse(txtprincipal.Text, out principal)) 
           {
               txtprincipal.BorderBrush = new SolidColorBrush(Colors.Red);
               return false;
           } 
           else
               txtprincipal.BorderBrush = new SolidColorBrush(Colors.Black);
    
           //Validate radio button check and also displaying error message.
           if (rad10years.IsChecked.Value) 
           {
               years = 10;
               return true;
           } else if (rad20years.IsChecked.Value) 
           {
               years = 20;
               return true;
           } else if (rad30years.IsChecked.Value) 
           {
               years = 30;
               return true;
           } else if (radother.IsChecked == true) 
           {
               //Other radio button tryparse 
               if (!double.TryParse(txtother.Text, out years)) {
                   MessageBox.Show("Not a Valid year.");
                   return false;
               }           
               
           } 
           else 
           {
               //Radiobutton color change
               MessageBox.Show("Please select number of years.");
               stkradbtns.Background = new SolidColorBrush(Colors.Red);
               return false;
           }
 
           return true;
       }
    }
