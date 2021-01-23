    var c =  GetAll(this, typeof(ComboBox));
    bool handledFirst = false;
    foreach (ComboBox cc in c)
    {
      if (handledFirst)
      {
        // Most likely case first
        w.Write(Environment.NewLine + "ComboBox Name " + cc.Name +
                Environment.NewLine + Environment.NewLine);
      }
      else
      {
        // This is first time through, don't forget to set the flag
        w.Write("ComboBox Name " + cc.Name + Environment.NewLine +
                Environment.NewLine);
        handledFirst = true;
      }
      [...]
    }
