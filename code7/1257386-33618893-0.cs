        private static void ConfigureMappings()
        {
            Mapper.CreateMap<DataRow, Product>()
                .ForMember(p => p.Name, mo => mo.MapFrom(row => row["Name"]))
                .ForMember(p => p.ID, mo => mo.MapFrom(row => row["ID"]))
                .ForMember(p => p.Specifications, mo => mo.ResolveUsing(MapSpecifications));
        }
        private static object MapSpecifications(ResolutionResult rr, DataRow row)
        {
            Dictionary<string, object> specs = new Dictionary<string, object>();
            // get all properties mapped in this mapping
            var maps = rr.Context.Parent.TypeMap.GetPropertyMaps();
            // loop all columns in the table
            foreach (DataColumn col in row.Table.Columns)
            {
                // if no property mapping exists, get value and add to dictionary
                if (!maps.Any(map => map.DestinationProperty.Name == col.ColumnName))
                {
                    specs.Add(col.ColumnName, row[col.ColumnName]);
                }
            }
            return specs;
        }
