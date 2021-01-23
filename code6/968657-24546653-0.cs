    if(!string.IsNullOrEmpty(textbox1.Text))
    {
       int outputValue=0;
       bool isNumber=false;
       isNumber=int.TryParse(textBox1.Text, out outputValue); 
       if(!isNumber)
         {
           MessageBox.Show("Type numbers in the textboxes");
         }
        else
        {
          // some code
        }
    }
