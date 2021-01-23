    public class EditorHelper : IEditorHelper
    {
        private readonly Editor _editor;
        public EditorHelper(Document document)
        {
            _editor = document.Editor;
        }
     public PromptDoubleResult PromptForDouble(string promptMessage, double defaultValue = 0.0)
     {
         var doubleOptions = new PromptDoubleOptions(promptMessage);
         if (Math.Abs(defaultValue - 0.0) > Double.Epsilon)
         {
             doubleOptions.UseDefaultValue = true;
             doubleOptions.DefaultValue = defaultValue;
         }
         var promptDoubleResult = _editor.GetDouble(doubleOptions);
         return promptDoubleResult;
     }
    public PromptResult PromptForKeywordSelection(
            string promptMessage, IEnumerable<string> keywords, bool allowNone, string defaultKeyword = "")
     {
        var promptKeywordOptions = new PromptKeywordOptions(promptMessage) { AllowNone = allowNone };
        foreach (var keyword in keywords)
        {
            promptKeywordOptions.Keywords.Add(keyword);
        }
        if (defaultKeyword != "")
        {
            promptKeywordOptions.Keywords.Default = defaultKeyword;
        }
        var keywordResult = _editor.GetKeywords(promptKeywordOptions);
        return keywordResult;
     }
    }
    
