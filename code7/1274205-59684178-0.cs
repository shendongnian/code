    public static void Convert(string GhostscriptPath, String pclFile, String pdfFile)
{
                        
    var args = $"-dNOPAUSE -sOutputFile=\"{pdfFile}\" -sDEVICE=pdfwrite \"{pclFile}\"";
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process.StartInfo.FileName = GhostscriptPath;
    process.StartInfo.Arguments = args;
    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
    process.Start();
    process.WaitForExit();
           
