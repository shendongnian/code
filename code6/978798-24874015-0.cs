    void FifteenButton_Click(object sender, EventArgs e)
    {
         Button btn = sender as Button;
         if(btn != null)
         {
              Console.WriteLine("Button clicked: " + btn.Text);
         }
    }
