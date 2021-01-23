        public class AClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [ForeignKey("AClassId")]
            public virtual List<PropertyValue> PropertyValues { get; set; }
        }
        // Id = 1, Name = "P1"
        // Id = 2, Name = "P2"
        // Id = 3, Name = "P3"
        public class PropertyValue
        {
            public int Id { get; set; }
            public int AClassId { get; set; }
            [ForeignKey("AClassId")]
            public virtual AClass A { get; set; }
            public int PropertyNameId { get; set; }
            [ForeignKey("PropertyNameId")]
            public virtual PropertyName PropertyName { get; set; }
            public string Value { get; set; }
        }
        // Id = 1, AClassId = 1, PropertyNameId = 1, Value = "p1 x1 y1"
        // Id = 2, AClassId = 1, PropertyNameId = 2, Value = "p1 x2 y2"
        // Id = 3, AClassId = 1, PropertyNameId = 3, Value = "p1 x3 y3"
        // Id = 4, AClassId = 2, PropertyNameId = 2, Value = "p2 x2 y2"
        // Id = 5, AClassId = 2, PropertyNameId = 3, Value = "p2 x3 y3"
        // Id = 6, AClassId = 2, PropertyNameId = 4, Value = "p2 x4 y4"
        // Id = 7, AClassId = 3, PropertyNameId = 3, Value = "p3 x3 y3"
        // Id = 8, AClassId = 3, PropertyNameId = 4, Value = "p3 x4 y4"
        // Id = 9, AClassId = 3, PropertyNameId = 5, Value = "p3 x5 y5"
        public class PropertyName
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [ForeignKey("PropertyId")]
            public virtual List<PropertyValue> PropertyValues { get; set; }
        }
        // Id = 1, PropertyName = "x1"
        // Id = 2, PropertyName = "x2"
        // Id = 3, PropertyName = "x3"
        // Id = 4, PropertyName = "x4"
        // Id = 5, PropertyName = "x5"
        public void DoStuff()
        {
            List<AClass> productlist = new List<AClass>();
            foreach (var product in productlist)
            {
                var productname = product.Name;
                foreach (var property in product.PropertyValues)
                {
                    var propertyname = property.PropertyName.Name;
                    var propertyvalue = property.Value;
                }
            }
        }
