    From 
        [XmlArray("audit_values")]
        [XmlArrayItem("audit_value", IsNullable = true)]
        public AuditValue[] AuditValues { get; set; }
    ​To
        [XmlElement("audit_value")]
        public AuditValue[] AuditValues { get; set; }
