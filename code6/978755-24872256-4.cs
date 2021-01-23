     public static object TryLoadCompiledType(this CompilerResults compilerResults, string typeName, params object[] constructorArgs)
        {
            if (compilerResults.Errors.HasErrors)
            {
                Log.Warn("Can not TryLoadCompiledType because CompilerResults.HasErrors");
                return null;
            }
            var type = compilerResults.CompiledAssembly.GetType(typeName);
            if (null == type)
            {
                Log.Warn("Compiled Assembly does not contain a type [" + typeName + "]");
                return null;
            }
            return Activator.CreateInstance(type, constructorArgs);
        }
