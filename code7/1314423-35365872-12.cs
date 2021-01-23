    public class RemoveEventArgs : EventArgs
    {
    public RemoveEventArgs ( string buttonId, string recordId)
    {
       this.ButtonId = buttonId;
       this.RecordId = recordId;
    }
        public string ButtonId {get;set;}
        public string RecordId {get;set;}
    }
