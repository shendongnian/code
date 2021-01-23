    public static void EnterPage([CallerFilePath]string memberName = "")
    {
        char seperatorChar = (char)typeof(System.IO.Path).GetTypeInfo().GetDeclaredField("DirectorySeparatorChar").GetValue(null);
        var file = System.IO.Path.GetFileNameWithoutExtension(memberName.Replace('\\', seperatorChar));
        Track(file);
    }
