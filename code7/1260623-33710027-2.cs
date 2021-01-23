    private void Form2_Load(object sender, EventArgs e)
    {
       foreach (TextBox txt in sourcePanel.Controls.OfType<TextBox>())
       {
          System.Diagnostics.Debug.WriteLine(txt.Text);
       }
    }
