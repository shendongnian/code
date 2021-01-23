    private void textBox1_PreviewKeyDown(object sender,  System.Windows.Input.KeyEventArgs e)
    {
      try
      {               
         char c = '\0';
         System.Windows.Input.Key key = e.Key;
         if ((key >= Key.A) && (key <= Key.Z))
         {
           c = (char)((int)'a' + (int)(key - Key.A));
         }
         else if ((key >= Key.D0) && (key <= Key.D9))
         {
           c = (char)((int)'0' + (int)(key - Key.D0));
         }
         else if ((key >= Key.NumPad0) && (key <= Key.NumPad9))
         {
           c = (char)((int)'0' + (int)(key - Key.NumPad0));
         }
         //here your logic
      }
      catch { }     
    }
}
