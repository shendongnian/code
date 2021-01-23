    /// <summary>
    /// Replaces document at provided index with new document.
    /// Use with Caution! If you continuously cycle using the output as the input,
    /// then you run repeated risks of information or quality loss.
    /// </summary>
    /// <param name="source">String. Full File Path to Source</param>
    /// <param name="documentN">String. Full File Path to new document</param>
    /// <param name="indexN">int. Index where file needs to go</param>
    public static void GhostscriptNetReplace(String source, String documentN, int indexN)
    {
        var list = new List<String>();
        var version = GhostscriptVersionInfo.GetLastInstalledVersion();
        var fullPath = Path.GetFullPath(source);
        int index = -1;
        using (var rasterizer = new Ghostscript.NET.Rasterizer.GhostscriptRasterizer())
        {
            rasterizer.Open(source, version, false);
            for (index = 0; index < rasterizer.PageCount; index++)
            {
                if (index != indexN)
                {
                    var extracted = Path.Combine(fullPath, String.Format("~1_{0}.jpg", index));
                    if (File.Exists(extracted))
                    {
                        File.Delete(extracted);
                    }
                    var img = rasterizer.GetPage(300, 300, index);
                    img.Save(extracted, ImageFormat.Jpeg);
                    list.Add(extracted);
                } else
                {
                    list.Add(documentN);
                }
            }
            if (index == indexN) // occurs if adding a page to the end
            {
                list.Add(documentN);
            }
        }
        var sb = new StringBuilder();
        foreach (var fileName in list)
        {
            var fmtSource = (fileName.IndexOf(' ') == -1) ? fileName : String.Format("\"{0}\"", fileName);
            sb.Append(fmtSource + " ");
        }
        var output_file = (source.IndexOf(' ') == -1) ? source : String.Format("\"{0}\"", source);
        using (var processor = new GhostscriptProcessor(version, false))
        {
            var gsArgs = new List<String>();
            gsArgs.Add("-empty"); // first argument is ignored. REF: http://stackoverflow.com/q/25202577/153923
            gsArgs.Add("-dBATCH");
            gsArgs.Add("-q");
            gsArgs.Add("-dNOPAUSE");
            gsArgs.Add("-dNOPROMPT");
            gsArgs.Add("-sDEVICE=pdfwrite");
            gsArgs.Add("-dPDFSETTINGS=/prepress");
            gsArgs.Add(String.Format(@"-sOutputFile={0}", output_file));
            gsArgs.Add(sb.ToString());
            processor.Process(gsArgs.ToArray());
        }
        foreach (var fileName in list) // delete the temp files
        {
            File.Delete(fileName);
        }
    }
