    private void btnbrowse_Click(object sender, EventArgs e)
        {
            
           String sf_no = Microsoft.VisualBasic.Interaction.InputBox("You are uploading File For SF NO. ", "Information", def, -1, -1);
          
           if (sf_no!="") //we got the sf_no
           {
               ofd.Multiselect = true;
               if (ofd.ShowDialog()==DialogResult.OK)//user select file(s)
               {
            
                    string[] result = ofd.FileNames;          
                    foreach (string y in result)
                    {
                      String path = System.IO.Path.GetDirectoryName(y);
                      String filename = System.IO.Path.GetFileName(y);
                      string[] row = new string[] { sf_no,path, filename };
                      dataGridView2.Rows.Add(row);
                     }
               }
               else
               {
               //handle what happen if user click cancel while selecting file  
               }
           }
           else
           {
           //handle what happen if user click cancel while entering SF NO
           }
 
    
        }
