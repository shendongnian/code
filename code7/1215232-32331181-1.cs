       public string Text
       {
          get
          {
             string text = (string)ViewState["Text"];
             return text ?? string.Empty;
          }
          set
          {
             ViewState["Text"] = value;
          }
      }
