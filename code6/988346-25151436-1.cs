    string tbname;    
    void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
    {
       try
    {      
         Entity.SaveChanges();
         tbname = Entity.Accessible.Name;        //save the name of the last edit textbox       
    }
     
     catch (Exception ex)
    {
        MessageBox.Show(string.Format("Error while saving. Check the current row for errors.{0}{0}Exception:{0}{0}{1}", Environment.NewLine, ex.Message));
         tbname.focus();               //will return the focus to that textbox last edited    
      }
    }
