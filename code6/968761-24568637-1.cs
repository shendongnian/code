    public MemoryStream GeneratePdf(StreamReader html)
        {
            html.BaseStream.Position = 0;
            var pdf = new MemoryStream();
            using (html)
            {
                Process p;
                var psi = new ProcessStartInfo
                {
                    FileName = @"C:\wkhtmltopdf\wkhtmltopdf.exe",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Arguments = Switches() + "-q -n --enable-smart-shrinking " + " - -"
                };
                p = Process.Start(psi);
                try
                {
                    if (p != null)
                    {
                        var stdin = p.StandardInput;
                        stdin.AutoFlush = true;
                        stdin.Write(html.ReadToEnd());
                        stdin.Dispose();
                    }
                    CopyStream(p.StandardOutput.BaseStream, pdf);
                    Console.WriteLine(  p.StandardOutput.CurrentEncoding.CodePage);
                    p.StandardOutput.Close();
                    pdf.Position = 0;
                    p.WaitForExit(10000);
                    return pdf;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    if (p != null) p.Dispose();
                }
            }
        }
