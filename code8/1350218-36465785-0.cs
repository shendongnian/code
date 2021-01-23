    int value= 0;
    for (int i = 0; i < set.Tables[1].Rows.Count; i++)
    {                                                
      value += Convert.ToInt32(set.Tables[1].Rows[i][0]);
    }
    
    Total.Text = value.ToString();
