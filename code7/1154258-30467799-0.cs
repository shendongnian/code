    public NotebookTypes NotebookType;
    
    public enum NotebookTypes{
       NotebookHP,
       NotebookDell
    }
    
    public string NotebookTypeName{
       get{
          switch(NotebookType){
             case NotebookTypes.NotebookHP:
                return "Notebook HP"; //You may read the language dependent value from xml...
             case NotebookTypes.NotebookDell:
                return "Notebook Dell"; //You may read the language dependent value from xml...
             default:
                throw new NotImplementedException("'" + typeof(NotebookTypes).Name + "." + NotebookType.ToString() + "' is not implemented correctly.");
          }
       }
    }
