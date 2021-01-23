    public class BaseModel
    {
        public bool IsIPUnique { get; set; }
        public bool IsMACUnique { get; set; }
        .... // other common properties
    }
    public class ServerJoin : BaseModel
    {
        .... //  properties specific to ServerJoin 
    }
    public class VMJoin : BaseModel
    {
        .... //  properties specific to VMJoin
    }
