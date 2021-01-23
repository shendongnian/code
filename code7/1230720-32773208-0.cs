	if (dr.Read())
    {
       string s1 = dr[3].ToString(); //this line tries to get 4th column. So, your query should return 4 columns.
       if ( s1 == "1")
       {
          MessageBox.Show("Login as Shedule");
       }
       else if (s1 == "2")
       {
          MessageBox.Show("Login as Operation");
       }
    }
    else
    {
       MessageBox.Show("error");
    }
