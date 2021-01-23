    #if !(NETFX_CORE || PORTABLE40 || PORTABLE)
                // look, I don't like using obsolete methods as much as you do but this is the only way
                // Assembly.Load won't check the GAC for a partial name
    #pragma warning disable 618,612
                assembly = Assembly.LoadWithPartialName(assemblyName);
    #pragma warning restore 618,612
    #elif NETFX_CORE || PORTABLE
                assembly = Assembly.Load(new AssemblyName(assemblyName));
    #else
                assembly = Assembly.Load(assemblyName);
    #endif
