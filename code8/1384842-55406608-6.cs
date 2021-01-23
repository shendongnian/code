    using (var memoryStream = new MemoryStream())
    {
        var emitResult = compilation.Emit(memoryStream);
        if (emitResult.Success)
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            var context = AssemblyLoadContext.Default;
            var assembly = context.LoadFromStream(memoryStream);
            assembly.GetType("ClassName").GetMethod("MethodName").Invoke(null, null);
        }
    }
