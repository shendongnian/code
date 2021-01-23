    private void btn_submit_Click(object sender, EventArgs e)
     {
         // definitions
    
         bool IsAllValidEntries = true;
    
         if (name.Length < 8)
         {
            //code here
             IsAllValidEntries = false;
         }
         else{  }
    
         if (email.Contains('@'))
         {
             if (email.Contains(".com") || email.Contains(".COM"))
             {
                 // your code here
             }
             else
             {
                 //code here
                 IsAllValidEntries = false;
             }
         }
         else
         {
             //code here
             IsAllValidEntries = false;
         }
    
         if (address.Length < 12)
         {
             //code here
             IsAllValidEntries = false;
         }
         else
         {
             txt_address.ForeColor = Color.Green;
         }
         if (course.Contains("Games Design") || course.Contains("Electronics") || 
         {
             txt_course.ForeColor = Color.Green;
         }
         else
         {
             //code here
             IsAllValidEntries = false;
         }
    
         if (phone.Length < 8)
         {
             //code here
             IsAllValidEntries = false;
         }
         else
         {
             txt_phone.ForeColor = Color.Green;
         }
    
         if (IsAllValidEntries)
             MessageBox.Show("Well done");
         else
             MessageBox.Show("oooops!");    
     }
