    public static void Main(string[] args)
    {
        Console.WriteLine(CheckFor45DotVersion(GetReleaseKey()));
        string assemblyName = "mscorlib";
        Assembly assembly = Assembly.Load(assemblyName);
        Console.WriteLine("Assembly: {0}", assembly.Location);
        long fullSize = new FileInfo(assembly.Location).Length;
        Console.WriteLine("Size: {0}", fullSize);
        var allOpCodes = typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public)
            .Where(x => x.FieldType == typeof(OpCode))
            .Select(x => (OpCode)x.GetValue(null));
        Dictionary<OpCode, int> opcodes = allOpCodes.ToDictionary(x => x, x => 0);
        long resourcesLength = 0;
        int skippedMethods = 0;
        int parsedMethods = 0;
        ParseAssembly(assembly, resource =>
        {
            ManifestResourceInfo info = assembly.GetManifestResourceInfo(resource);
            if (info.ResourceLocation.HasFlag(ResourceLocation.Embedded))
            {
                using (Stream stream = assembly.GetManifestResourceStream(resource))
                {
                    resourcesLength += stream.Length;
                }
            }
        }, method =>
        {
            if (method.MethodImplementationFlags.HasFlag(MethodImplAttributes.InternalCall))
            {
                skippedMethods++;
                return;
            }
            if (method.Attributes.HasFlag(MethodAttributes.PinvokeImpl))
            {
                skippedMethods++;
                return;
            }
            if (method.IsAbstract)
            {
                skippedMethods++;
                return;
            }
            parsedMethods++;
            IList<Instruction> instructions = method.GetInstructions();
            foreach (Instruction instruction in instructions)
            {
                int num;
                opcodes.TryGetValue(instruction.OpCode, out num);
                opcodes[instruction.OpCode] = num + 1;
            }
        });
        Console.WriteLine("Of which resources: {0}", resourcesLength);
        Console.WriteLine();
        Console.WriteLine("Skipped: {0} methods", skippedMethods);
        Console.WriteLine("Parsed: {0} methods", parsedMethods);
        int gained = 0;
        int gainedFixedNumber = 0;
        // m1: Ldc_I4_M1
        var shortOpcodes = opcodes.Where(x =>
            x.Key.Name.EndsWith(".s") ||
            x.Key.Name.EndsWith(".m1") ||
                // .0 - .9
            x.Key.Name[x.Key.Name.Length - 2] == '.' && char.IsNumber(x.Key.Name[x.Key.Name.Length - 1]));
        foreach (var @short in shortOpcodes)
        {
            OpCode opCode = @short.Key;
            string name = opCode.Name.Remove(opCode.Name.LastIndexOf('.'));
            OpCode equivalentLong = opcodes.Keys.First(x => x.Name == name);
            int lengthShort = GetLength(opCode.OperandType);
            int lengthLong = GetLength(equivalentLong.OperandType);
            int gained2 = @short.Value * (lengthLong - lengthShort);
            if (opCode.Name.EndsWith(".s"))
            {
                gained += gained2;
            }
            else
            {
                gainedFixedNumber += gained2;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Gained {0} bytes from short arguments", gained);
        Console.WriteLine("Gained {0} bytes from \"fixed\" number", gainedFixedNumber);
    }
    private static int GetLength(OperandType operandType)
    {
        switch (operandType)
        {
            case OperandType.InlineNone:
                return 0;
            case OperandType.ShortInlineVar:
            case OperandType.ShortInlineI:
            case OperandType.ShortInlineBrTarget:
                return 1;
            case OperandType.InlineVar:
                return 2;
            case OperandType.InlineI:
            case OperandType.InlineBrTarget:
                return 4;
        }
        throw new NotSupportedException();
    }
    private static void ParseAssembly(Assembly assembly, Action<string> resourceAction, Action<MethodInfo> action)
    {
        string[] names = assembly.GetManifestResourceNames();
        foreach (string name in names)
        {
            resourceAction(name);
        }
        Module[] modules = assembly.GetModules();
        foreach (Module module in modules)
        {
            ParseModule(module, action);
        }
    }
    private static void ParseModule(Module module, Action<MethodInfo> action)
    {
        MethodInfo[] methods = module.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (MethodInfo method in methods)
        {
            action(method);
        }
        Type[] types = module.GetTypes();
        foreach (Type type in types)
        {
            ParseType(type, action);
        }
    }
    private static void ParseType(Type type, Action<MethodInfo> action)
    {
        if (type.IsInterface)
        {
            return;
        }
        // delegate (in .NET all delegates are MulticastDelegate
        if (type != typeof(MulticastDelegate) && typeof(MulticastDelegate).IsAssignableFrom(type))
        {
            return;
        }
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (MethodInfo method in methods)
        {
            action(method);
        }
        Type[] nestedTypes = type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);
        foreach (Type nestedType in nestedTypes)
        {
            ParseType(nestedType, action);
        }
    }
    // Adapted from https://msdn.microsoft.com/en-us/library/hh925568.aspx
    private static int GetReleaseKey()
    {
        using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
        {
            // .NET 4.0
            if (ndpKey == null)
            {
                return 0;
            }
            int releaseKey = (int)ndpKey.GetValue("Release");
            return releaseKey;
        }
    }
    // Checking the version using >= will enable forward compatibility,  
    // however you should always compile your code on newer versions of 
    // the framework to ensure your app works the same. 
    private static string CheckFor45DotVersion(int releaseKey)
    {
        if (releaseKey >= 393273)
        {
            return "4.6 RC or later";
        }
        if ((releaseKey >= 379893))
        {
            return "4.5.2 or later";
        }
        if ((releaseKey >= 378675))
        {
            return "4.5.1 or later";
        }
        if ((releaseKey >= 378389))
        {
            return "4.5 or later";
        }
        // This line should never execute. A non-null release key should mean 
        // that 4.5 or later is installed. 
        return "No 4.5 or later version detected";
    }
