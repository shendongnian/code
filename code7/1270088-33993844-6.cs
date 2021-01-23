    private void textBox1_PreviewKeyDown(object sender,  System.Windows.Input.KeyEventArgs e)
    {
      try
      {               
         KeysConverter kc = new KeysConverter();
         string keyChar = kc.ConvertToString(e.Key);
         //here your logic
      }
      catch { }     
    }
}
