    var assembly = AssemblyDefinition.ReadAssembly(SourceAssemblyPath);
    var module = assembly.MainModule;
    
    var q = from type in module.Types
            from method in type.Methods
            from parameter in method.Parameters
            where parameter.HasCustomAttributes
            from attribute in parameter.CustomAttributes
            where attribute.AttributeType.FullName == NotNullAttribute.FullName
            select new { Method = method, Parameter = parameter };
    
    foreach (var item in q)
    {
        item.Method.InsertBefore()
            .Ldarg(item.Parameter.Name)
            .IfNull()
                .Throw<ArgumentNullException>()
            .EndIf();
    }
    
    SourceAssemblyPath = SourceAssemblyPath.Replace("\\debug\\", "\\release\\");
    assembly.Write(SourceAssemblyPath, new WriterParameters { WriteSymbols = false });
