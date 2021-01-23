    string test = "animal?species";
    string [] splittedtest = string.Split(new Char[] { '?', '\' },
                                 StringSplitOptions.RemoveEmptyEntries);
    //string[] splittedtest = test.Split('?');
    for(int i = 0;i<splittedtest.length;i++)
    {
       // do your stuffs like below,  
       // DataGridView1.Rows[DataGridView.SelectedRows[0].Index].Cells[X].Text = splittedtest[i];
       // where X is the column you want to read. 
    }
