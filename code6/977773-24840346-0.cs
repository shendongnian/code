    public static void CleanCustomAttributes(AssemblyDefinition asmdef)
    {
        foreach (ModuleDefinition ModuleDef in asmdef.Modules)
        {
            foreach (TypeDefinition TypeDef in ModuleDef.Types)
            {
                foreach (CustomAttribute CustomAttrib in TypeDef.CustomAttributes)
                {
                    if (CustomAttrib.AttributeType.FullName == "System.Reflection.ObfuscationAttribute")
                    {
                        TypeDef.CustomAttributes.Remove(CustomAttrib);
                        break;
                    }
                }
            }
        }
    }
