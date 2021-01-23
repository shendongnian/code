     private void button3_Click(object sender, EventArgs e)
            {
               bool test  =true  ;
    
                test= ValidateControle(textBox1, 1);
    
               test= ValidateControle(comboBox1,1);
    
               if (test)
               {
                   //continue working and saving the record
               }
               else
               {
                   //Stop and traancate recording
    
               }
    
            }
