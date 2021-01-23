    ... some code here
        Prm[5] = new SqlParameter("@comments", txtComments.Text);
        Prm[6] = new SqlParameter("@fpath", fPath);
            // add this loop into your code and trace the program. 
            foreach (var item in Prm)
            {
                var len = item.Value.ToString().Length;
                // check len to see if it is bigger than of size of the corresponding column
                // if len is bigger than your column size, that is the issue
                // and you need to alter that column to store bigger string
            }
        DB_Functions.ExcuteNonQuery("SP_A_Data", Prm);
        lblState.Text = "Your Data is Saved (: ";
        clear();
        lblState.Text = "Added";
    ... some code here
