    using System.Reflection;
    ...
    FieldInfo fi = this
      .GetType()
      .GetField("textbox" + textbox1.Text, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
    
    if (fi != null) {
      TextBox result = fi.GetValue(this) as TextBox;
      ... 
    }
