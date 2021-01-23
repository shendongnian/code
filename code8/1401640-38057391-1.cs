      private String m_RawText;
      // Text as it's obtained from, say, database 
      private string rawText { 
        get {
          if (null == m_RawText)
            m_RawText = ReadValueFromDataBase();
          return m_RawText;
        } 
        set {
          if (m_RawText != value) {
            UpdateValueInDataBase(value);
            m_RawText = value;
          }
        }  
      }
    
      // Friendly encoded text, for say UI
      public string Text {
        get {
          return EncondeText(rawTex);
        }
        set {
          rawText = DecodeText(value);
    
          RaisePropertyChanged("Text");
       }
     }  
     // Here we want rawText
     public void PerformSomething() {
       String text = rawText; // we want raw text...
       ...
     } 
