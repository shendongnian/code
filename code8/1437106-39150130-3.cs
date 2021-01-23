    string b = "";
    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    {
        b += ds.Tables[0].Rows[i].ItemArray[0] + " " + ds.Tables[0].Rows[i].ItemArray[1] + "\n";
    }
    MessageBox.Show(b);
