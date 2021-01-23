            Assembly csharpDisplay = typeof(CodeWalker).Assembly;
            renderer.MetadataReferences.Add(MetadataReference.CreateFromAssembly(assembly));     
            csharpDisplay.GetReferencedAssemblies()
                         .ToList()
                         .ForEach(a => renderer.MetadataReferences.Add(MetadataReference.CreateFromAssembly(Assembly.Load(a))));
