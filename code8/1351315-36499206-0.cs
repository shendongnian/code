    public class Document
    {
        public int DocumentId { get; set; }
        public DocumentState State { get; set; }
        // other properties ...
    }
    public enum DocStateType
    {
        Default = 0,
        Draft = 1,
        Archived = 2,
        Deleted = 3
    }
    public class DocumentState
    {
        public DocumentState(DocStateType type)
        {
            this.Type = type;
            this.TypeId = (int) type;
        }
        public DocumentState(int typeId)
        {
            if (Enum.IsDefined(typeof (DocStateType), typeId))
                this.Type = (DocStateType) typeId;
            else
                throw new ArgumentException("Illegal DocStateType-ID: " + typeId, "typeId");
            this.TypeId = typeId;
        }
        public int TypeId { get; set; }
        public DocStateType Type { get; set; }
        // other properties ...
    }
