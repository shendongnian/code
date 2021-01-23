    public static class TextBoxExtensions {
      public static void WritePublicText(this TextBox textBox, string value) {
        if (null == textBox)
          throw new ArgumentNullException("textBox");
        textBox.Text = value;
      }
    }
   ...
 
    // Extension method instead of property
    textBox1.WritePublicText(
        "Text to display\r\n"
      + "More Text\r\n"
      + "More Text2\r\n");
  
