            string fileLoc = //my path to git.exe
            FileStream fs = new FileStream(fileLoc, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bin = br.ReadBytes(Convert.ToInt32(fs.Length));
            foreach (byte b in bin)
            {
                Console.Write((char)b);
            }
            fs.Close()
