    var prcPath = "PATH"; //a path to store the temporary files
    var pageCount = GetPDFPageCount(source);
    var list = SplitPDFatIndex(source, prcPath, indexN);
    private static List<String> SplitPDFatIndex(String pathToFile, String tempPath, int index)
    {
        var outList = new List<String>();
        outList.Add(SlicePDFatIndex(pathToFile, tempPath, index, true);
        outlist.Add(null); // Alternatively modify method below to permit pulling page N
        outList.Add(SlicePDFatIndex(pathToFile, tempPath, index, false);
        return outList;
    }
    private static String SlicePDFatIndex(String pathToFile, String tempPath, int index, bool lessThanIndex)
    {
        using (var processor = new GhostscriptProcessor(version, false))
        {
            var pageFrom = 1;
            var pageTo = index - 1;
            var name = tempPath + "temp_left.pdf";
            if (!lessThanIndex)
            {
                pageFrom = index + 1;
                pageTo = pageCount;
                name = tempPath + "temp_right.pdf";
            }
            
            var gsArgs = new List<String>();
            gsArgs.Add("-empty");
            gsArgs.Add("-dBATCH");
            gsArgs.Add("-q");
            gsArgs.Add("-dNOPAUSE");
            gsArgs.Add("-dNOPROMPT");
            gsArgs.Add("-sDEVICE=pdfwrite");
            gsArgs.Add("-dPDFSETTINGS=/prepress");
            gsArgs.Add(String.Format(@"-f{0}", pathToFile);
            gsArgs.Add("-dFirstPage=" + pageFrom.ToString());
            gsArgs.Add("-dLastPage=" + pageTo.ToString());
            gsArgs.Add(String.Format(@"-sOutputFile={0}", name));
            processor.Process(@"-f{0}", pathToFile);
            
            return name;
    }
    private static int GetPDFPageCount(String pathToFile)
    {
        var count;
        var GhostscriptViewer viewer;
    
        viewer = new GhostscriptViewer();
        viewer.ShowPageAfterOpen = false;
        viewer.ProgressiveUpdate = false;
        viewer.Open(source); // try (source, version, false) or (source, version, true) if for some reason it hangs up here
        count = viewer.LastPageNumber;
        viewer.Close()
        return count;
    }
