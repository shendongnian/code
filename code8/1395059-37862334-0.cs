    class BaseRecord
    {
        public Int32 PrimaryKey { get; set; }
        public String SysTime { get; set; }
    }
    class ProcTemplateRecord : BaseRecord
    {
        public String ProcName { get; set; }
        public String Comments { get; set; }
    }
