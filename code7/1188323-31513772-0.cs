    public class Rootobject
    {
        public Graph[] graph { get; set; }
        public Context context { get; set; }
    }
    
    public class Context
    {
        public string hasDesignation { get; set; }
        public string hasNote { get; set; }
        public string hasCreator { get; set; }
        public string hasDefinition { get; set; }
        public string label { get; set; }
        public string hasIdPCA { get; set; }
        public string hasCreationDate { get; set; }
        public string hasStatus { get; set; }
        public string defaultRdsId { get; set; }
        public string hasDesignationAbbrev { get; set; }
        public Sameas sameAs { get; set; }
        public Hassuperclass hasSuperclass { get; set; }
        public Hassubclass hasSubclass { get; set; }
        public string hasRegistrarAuth { get; set; }
        public string hasRegistrar { get; set; }
        public Rdswipequivalent rdsWipEquivalent { get; set; }
        public string rds { get; set; }
        public string p2 { get; set; }
        public string owl { get; set; }
        public string rdf { get; set; }
        public string afn { get; set; }
        public string xsd { get; set; }
        public string fn { get; set; }
        public string oldrdl { get; set; }
        public string rdfs { get; set; }
        public string rdl { get; set; }
        public string list { get; set; }
        public string dc { get; set; }
    }
    
    public class Sameas
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    
    public class Hassuperclass
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    
    public class Hassubclass
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    
    public class Rdswipequivalent
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    
    public class Graph
    {
        public string id { get; set; }
        public string type { get; set; }
        public string defaultRdsId { get; set; }
        public string hasCreationDate { get; set; }
        public string hasCreator { get; set; }
        public string hasDefinition { get; set; }
        public string hasDesignation { get; set; }
        public string hasIdPCA { get; set; }
        public string hasStatus { get; set; }
        public string label { get; set; }
        public string sameAs { get; set; }
        public string hasDesignationAbbrev { get; set; }
        public string hasNote { get; set; }
        public string hasRegistrar { get; set; }
        public string hasRegistrarAuth { get; set; }
        public string hasSubclass { get; set; }
        public string hasSuperclass { get; set; }
        public string rdsWipEquivalent { get; set; }
    }
