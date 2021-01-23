    void ClearAllText(Control formTest)
    {
        foreach (Control c in formTest.Controls)
        {
          if (c is TextBox)
             ((TextBox)c).Clear();
          else
             ClearAllText(c);
        }
    }
