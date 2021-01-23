            var serializer = JsonSerializer.CreateDefault();
            var converter = new KeyedListMergeConverter(serializer.ContractResolver);
            serializer.Converters.Add(converter);
            using (var reader = new StringReader(updateJson))
            {
                serializer.Populate(reader, parent);
            }
