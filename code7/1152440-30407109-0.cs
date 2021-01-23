    public static void SetText(string text, TextDataFormat format)
    {
       if (string.IsNullOrEmpty(text))
       {
          throw new ArgumentNullException("text");
       }
       if (!System.Windows.Forms.ClientUtils.IsEnumValid(format, (int) format, 0, 4))
       {
          throw new InvalidEnumArgumentException("format", (int) format, typeof(TextDataFormat));
       }
       System.Windows.Forms.IDataObject data = new DataObject();
       data.SetData(ConvertToDataFormats(format), false, text);
       SetDataObject(data, true);
    }
