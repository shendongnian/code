     List<PortableExecutableReference> refs = new List<PortableExecutableReference>();
     refs.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "mscorlib.dll")));
     refs.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.dll")));
     refs.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Core.dll")));
     refs.Add(MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "System.Runtime.dll")));
     refs.Add(MetadataReference.CreateFromFile(Assembly.GetEntryAssembly().Location));
