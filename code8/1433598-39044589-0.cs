    private void test2_Click(object sender, EventArgs e)
    {
        StreamReader objReader = new StreamReader("C:\\testing\\mslogon.log");
        string sLine = "";
        ArrayList arrText = new ArrayList();
        MessageBox.Show("File Read");
        while (sLine != null)
        {
            sLine = objReader.ReadLine();
            if (sLine != null)
            {
                arrText.Add(sLine);
            }
        }
        foreach(string x in arrText)
        {
          if (x.Contains("Word Invalid Found"))
          {
            MessageBox.Show("Nothing Found");
          }
          else
          {
            MessageBox.Show("Nada");
          }
        }
    }
