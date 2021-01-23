    var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
    path = Path.Combine(path, "tessdata");
    path = path.Replace("file:\\", "");
    using (var engine = new TesseractEngine(path, "eng", EngineMode.Default))
    {
        engine.SetVariable("tessedit_char_whitelist", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        engine.SetVariable("tessedit_unrej_any_wd", true);
        using (var page = engine.Process(bitmap, PageSegMode.SingleLine))
            res = page.GetText();
    }
