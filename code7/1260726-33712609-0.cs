    // include using reference to Microsoft.Win32;
    static IEnumerable<string> GetTextExtensions()
    {
        var defaultcomp = StringComparison.InvariantCultureIgnoreCase;
        var root = Registry.ClassesRoot;
        foreach (var s in root.GetSubKeyNames()
            .Where(a => a.StartsWith(".")))
        {
            using (RegistryKey subkey = root.OpenSubKey(s))
            {
                if (subkey.GetValue("Content Type")?.ToString().StartsWith("text/", defaultcomp) == true)
                    yield return s;
                else if (subkey.GetValue("PerceivedType")?.ToString().Equals("text", defaultcomp) == true)
                    yield return s;
                else
                {
                    using (var ph = subkey.OpenSubKey("PersistentHandler"))
                    {
                        if (ph?.GetValue("")?.ToString().Equals("{5e941d80-bf96-11cd-b579-08002b30bfeb}", defaultcomp) == true)
                            yield return s;
                    }
                }
            }
        }
    }
