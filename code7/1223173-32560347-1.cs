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
    
    private void GetAllDialogLines(List<DialogLine> dialogLines, List<DialogLine> result)
    {
    
       foreach(var dl in  dialogLines)
       {
          result.Add(dl); 
       if(dl.HasChilds)
       {
           GetAllDialogLines(dl, result);
       }
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
