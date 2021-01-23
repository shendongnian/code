    protected void RadListBox2_Inserted(object sender, RadListBoxEventArgs e)
    {
        ArrayList myTest = new ArrayList();
        //StringBuilder s = new StringBuilder();
        for (int i = 0; i < e.Items.Count; i++)
        {
            myTest.Add(e.Items[i].Text);    
           
        } 
         foreach (string x in myTest)
            {
                    lblInsertedList2.Text += x + ", " + "&nbsp;";
            }
    }
