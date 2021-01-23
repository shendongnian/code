    private void RegisterFileExtension(string fileName)
    {
        var ext = Path.GetExtension(fileName);
        var key = Registry.CurrentUser.CreateSubKey(
            $@"Software\Microsoft\MediaPlayer\Player\Extensions\{ext}"); // C# 6.0
        key.SetValue("Permissions", 1);
        key.SetValue("Runtime", 1);
    }
