        void foo(IEnumerable<Type> types)
        {
            var rs = new XmlSchemaSimpleTypeRestriction
            {
                BaseTypeName = new XmlQualifiedName("string", XmlSchema.Namespace)
            };
            foreach (var t in types)
            {
                rs.Facets.Add(new XmlSchemaEnumerationFacet {Value = t.Name});
            }
            var schema = new XmlSchema();
            schema.Items.Add(new XmlSchemaSimpleType
            {
                Name = "ParamTypeRestriction",
                Content = rs
            });
            schema.Write(...);
        }
