        public static void SetText(string text)
        { 
            ....
            SetText(text, TextDataFormat.UnicodeText);
        }
 
        public static void SetText(string text, TextDataFormat format) 
        {
            ....
            SetDataInternal(DataFormats.ConvertToDataFormats(format), text);
        }
        public static void SetData(string format, object data) 
        {
            ....
            SetDataInternal(format, data);
        } 
