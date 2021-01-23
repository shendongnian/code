    Form2 Form_Prop;
    public void toolStripButton1_Click(object sender, EventArgs e)
         {
             if (Form_Prop == null)
             {
                 Form_Prop = new Form2();
                 Form_Prop.Show();       
                 
             }
         else
         {
             Form_Prop.WindowState = FormWindowState.Normal;
         }
     }
