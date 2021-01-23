    public static Version GetAssemblyVersion (Assembly asm)
    {
        var attribute = Attribute.GetCustomAttribute(asm, typeof(AssemblyFileVersionAttribute), true) as AssemblyFileVersionAttribute;
        return new Version(attribute.Version);
    }
