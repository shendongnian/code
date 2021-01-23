        public static Schema GetSchema(XElement root)
        {
            XNamespace edmx = root.GetNamespaceOfPrefix("edmx");
            XNamespace edm = root.Element(edmx + "DataServices").Elements().First().GetDefaultNamespace();
            var result = from s in root.Element(edmx + "DataServices").Elements(edm + "Schema")
                         select new
                         {
                             Namespace = (string)s.Attribute("Namespace"),
                             EntityTypes = from e in s.Elements(edm + "EntityType")
                                           select new EntityType
                                           {
                                               Name = (string)e.Attribute("Name"),
                                               Key = from k in e.Element(edm + "Key").Elements(edm + "PropertyRef")
                                                     select (string)k.Attribute("Name"),
                                               Properties = from p in e.Elements(edm + "Property")
                                                            select new Property
                                                            {
                                                                Name = (string)p.Attribute("Name"),
                                                                Type = (string)p.Attribute("Type"),
                                                                Nullable = (bool)p.Attribute("Nullable", true),
                                                                MaxLength = (string)p.Attribute("MaxLength"),
                                                                FixedLength = (bool)p.Attribute("FixedLength", false),
                                                            },
                                               NavigationProperties = from p in e.Elements(edm + "NavigationProperty")
                                                                      select new NavigationProperty
                                                                      {
                                                                          Name = (string)p.Attribute("Name"),
                                                                          Relationship = (string)p.Attribute("Relationship"),
                                                                          ToRole = (string)p.Attribute("ToRole"),
                                                                          FromRole = (string)p.Attribute("FromRole"),
                                                                      }
                                           },
                             Associations = from a in s.Elements(edm + "Association")
                                            select new Association
                                            {
                                                Name = (string)a.Attribute("Name"),
                                                Ends = from et in a.Elements(edm + "End")
                                                       select new AssociationEnd
                                                       {
                                                           Type = (string)et.Attribute("Type"),
                                                           Role = (string)et.Attribute("Role"),
                                                           Multiplicity = (string)et.Attribute("Multiplicity"),
                                                       }
                                            },
                             AssociationSets = from @as in s.Elements(edm + "EntityContainer").Elements(edm + "AssociationSet")
                                               select new AssociationSet
                                               {
                                                   Name = (string)@as.Attribute("Name"),
                                                   Association = (string)@as.Attribute("Association"),
                                                   Ends = from r in @as.Elements(edm + "End")
                                                          select new AssociationSetEnd
                                                          {
                                                              Role = (string)r.Attribute("Role"),
                                                              EntitySet = (string)r.Attribute("EntitySet"),
                                                          },
                                               },
                            EntitySets = from @es in s.Elements(edm + "EntityContainer").Elements(edm + "EntitySet")
                                         select new EntitySet
                                                {
                                                    Name = (string)@es.Attribute("Name"),
                                                    EntityType = (string)@es.Attribute("EntityType"),
                                                },
                         };
            return new Schema
            {
                Namespace = result.First().Namespace,
                EntityTypes = result.SelectMany(x => x.EntityTypes).ToDictionary(x => x.Name),
                Associations = result.SelectMany(x => x.Associations).ToDictionary(x => x.Name),
                AssociationSets = result.SelectMany(x => x.AssociationSets).ToDictionary(x => x.Name),
                EntitySets = result.SelectMany(x => x.EntitySets).ToDictionary(x => x.Name),
            };
        }
