        static int iMaxLogLength = 15000;
        static int iTrimmedLogLength = -2000;
        static public void writeToFile2(string strMessage, string strLogFileDirectory, int iLogLevel)
        {
            string strFile = strLogFileDirectory + "log.log";
            try
            {
                FileInfo fi = new FileInfo(strFile);
                Byte[] bytesRead = null;
                if (fi.Length > iMaxLogLength)
                {
                    using (BinaryReader br = new BinaryReader(File.Open(strFile, FileMode.Open)))
                    {
                        // 3. Go to the end of the file and backup some
                        br.BaseStream.Seek(iTrimmedLogLength, SeekOrigin.End);
                        // 4. Read that.
                        bytesRead = br.ReadBytes((-1 * iTrimmedLogLength));
                    }
                }
                byte[] newLine = System.Text.ASCIIEncoding.ASCII.GetBytes(Environment.NewLine);
                FileStream fs = null;
                if (fi.Length < iMaxLogLength)
                    fs = new FileStream(strFile, FileMode.Append, FileAccess.Write, FileShare.Read);
                else
                    fs = new FileStream(strFile, FileMode.Create, FileAccess.Write, FileShare.Read);
                using (fs)
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(strMessage);
                    fs.Write(sendBytes, 0, sendBytes.Length);
                    fs.Write(newLine, 0, newLine.Length);
                    if (bytesRead != null)
                    {
                        Byte[] lineBreak = Encoding.ASCII.GetBytes("### *** *** *** Old Log Start Position *** *** *** *** ###");
                        fs.Write(lineBreak, 0, lineBreak.Length);
                        fs.Write(newLine, 0, newLine.Length);
                        fs.Write(bytesRead, 0, bytesRead.Length);
                        fs.Write(newLine, 0, newLine.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                ; // Write to event or something
            }
        }
