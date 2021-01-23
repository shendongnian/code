    public class FlowDocumentFindMessage
    {
       public string PageName { get; private set; }
       // or some other properties go here
       FlowDocumentFindMessage(string pageName){
              this.PageName = pageName
       }
    }
