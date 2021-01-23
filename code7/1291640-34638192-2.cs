    private bool ServerFileIsNewer(string clientFileVersion, FileVersionInfo serverFile)
    {
        Version client = new Version(clientFileVersion);
        Version server = new Version(string.Format("{0}.{1}.{2}.{3}", serverFile.FileMajorPart, serverFile.FileMinorPart, serverFile.FileBuildPart, serverFile.FilePrivatePart));
        return server > client;
    }
