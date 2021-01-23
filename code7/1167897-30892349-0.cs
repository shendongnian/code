        private PEFileKinds GetFileType(string inFilename)
        {
            using (var fs = new FileStream(inFilename, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[4];
                fs.Seek(0x3C, SeekOrigin.Begin);
                fs.Read(buffer, 0, 4);
                var peoffset = BitConverter.ToUInt32(buffer, 0);
                fs.Seek(peoffset + 0x5C, SeekOrigin.Begin);
                fs.Read(buffer, 0, 1);
                if (buffer[0] == 3)
                {
                    return PEFileKinds.ConsoleApplication;
                }
                else if (buffer[0] == 2)
                {
                    return PEFileKinds.WindowApplication;
                }
                else
                {
                    return PEFileKinds.Dll;
                }
            }
        }
