    public List<DialogLine> GetAllDialogLines(DialogLine rootDialogLine)
    {
       List<DialogLine> allLines = new List<DialogLine>();
    
       if(rootDialogLone.HasChilds)
       {
          GetAllDialogLines(rootDialogLine, allLines);
       }
       else
       {
          allLines.Add(rootDialogLine);
       }
    
       return allLines;
    }
    
    private void GetAllDialogLines(DialogLine dialogLine, List<DialogLine> lines)
    {
    
       lines.Add(dialogLine);
       if(dialogLine.HasChilds)
       {
           GetAllDialogLines(dialogLine.First(), lines);
       }
    }
    public class DialogLine
    {
        public string line;
        public string answer;
    
        public bool HasChilds
        {
             get {return dialogLines.count > 0;}
        }
    
        /// <summary>
        /// This will enable the dialog giver to continue speaking of the same theme (use for long dialogs!)
        /// </summary>
        public List<DialogLine> dialogLines = new List<DialogLine>();
    }
