            var primitive = new Primitive
            {
                type = "some type",
                vertices = new[] { 1.0f, 2.0f },
                indices = Enumerable.Range(0, 10000).Select(i => 0).ToArray(),
                edgeIndices = new[] { 0, 1 },
                scene = new Scene { Name = "Should Not Be Serialized" }
            };
            var writer = new JsonWriter(new DataWriterSettings(new JsonResolverStrategy()));
            var json = writer.Write(primitive);
            var reader = new JsonReader(new DataReaderSettings(new JsonResolverStrategy()));
            var primitiveBack = reader.Read<Primitive>(json);
            Debug.Assert(primitiveBack.indices.SequenceEqual(primitive.indices));
