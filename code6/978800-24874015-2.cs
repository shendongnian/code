    void FifteenButton_Click(object sender, EventArgs e)
    {
         Button btn = sender as Button;
         if(btn != null)
         {
              string[] xy = btn.Tag.ToString().Split('_');
              Console.WriteLine("Button clicked: " + xy[0] + "," + xy[1]);
         }
    }
