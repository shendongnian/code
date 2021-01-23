    private void btAddElements_Click(object sender, EventArgs e)
        {
           // string Elements="";
             int choice=0;
    
          bool result = Int32.TryParse(txtbElements.Text.ToString(), out number);
              if (result)         
                {
                     choice=number;
                }       
    
            switch(choice)
            {
    
                case 2: 
                    lblElements.Text = string.Format ("A = 1,2,3 ");
                     break;
    
                //other cases.
            }
    
        }
