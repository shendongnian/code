        public class AClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [ForeignKey("AClassId")]
            public virtual List<PropertyValue> PropertyValues { get; set; }
        }
        // Id = 1, Name = "Product 1"
        // Id = 2, Name = "Product 2"
        // Id = 3, Name = "Product 3"
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
        // Id = 1, AClassId = 1, PropertyNameId = 1, Value = "y1"
        // Id = 2, AClassId = 1, PropertyNameId = 2, Value = "y2"
        // Id = 3, AClassId = 1, PropertyNameId = 3, Value = "y3"
        // Id = 4, AClassId = 2, PropertyNameId = 2, Value = "y2"
        // Id = 5, AClassId = 2, PropertyNameId = 3, Value = "y3"
        // Id = 6, AClassId = 2, PropertyNameId = 4, Value = "y4"
        // Id = 7, AClassId = 3, PropertyNameId = 3, Value = "y3"
        // Id = 8, AClassId = 3, PropertyNameId = 4, Value = "y4"
        // Id = 9, AClassId = 3, PropertyNameId = 5, Value = "y5"
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
