        public class AClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [ForeignKey("AClassId")]
            public virtual List<PropertySet> PropertySets { get; set; }
        }
        public class PropertySet
        {
            public int Id { get; set; }
            public int AClassId { get; set; }
            [ForeignKey("AClassId")]
            public virtual AClass A { get; set; }
            public int PropertyNameId_Column1 { get; set; }
            [ForeignKey("PropertyNameId_Column1")]
            public virtual PropertyName PropertyName_Column1 { get; set; }
            public string Value_Column1 { get; set; }
            public int PropertyNameId_Column2 { get; set; }
            [ForeignKey("PropertyNameId_Column2")]
            public virtual PropertyName PropertyName_Column2 { get; set; }
            public string Value_Column2 { get; set; }
            public int PropertyNameId_Column3 { get; set; }
            [ForeignKey("PropertyNameId_Column3")]
            public virtual PropertyName PropertyName_Column3 { get; set; }
            public string Value_Column3 { get; set; }
        }
        public class PropertyName
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [ForeignKey("PropertyNameId_Column1")]
            public virtual List<PropertySet> PropertySets_Column1 { get; set; }
            [ForeignKey("PropertyNameId_Column2")]
            public virtual List<PropertySet> PropertySets_Column2 { get; set; }
            [ForeignKey("PropertyNameId_Column3")]
            public virtual List<PropertySet> PropertySets_Column3 { get; set; }
        }
