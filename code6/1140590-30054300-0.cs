    private void openAndSaveAsBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dirPath = @"C:\";
            //read from folder: C:\
            //create directory if it doesn't exist
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string fileName = @dirPath + "/TestFile.bin";
            
            //Create binary file if it doesn't exist
            if (!File.Exists(fileName))
            {
                //File doesn't exist - create file
                FileStream fs = new FileStream(fileName, FileMode.CreateNew);
                BinaryWriter bw = new BinaryWriter(fs);
                byte[] byteArray = { 0x48, 0x45, 0x4C, 0x4C, 0x4F }; //HELLO!
                for (int i = 0; i < byteArray.Length; i++)
                {
                    bw.Write(byteArray[i]);
                }
                bw.Close();
                fs.Close();
            }
            // reads back
            FileStream fsRead = new FileStream(fileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fsRead);
            for (int i = 0; i < fsRead.Length; i++)
            {
                MessageBox.Show(br.ReadByte().ToString());
            }
            br.Close();
            fsRead.Close();
        }
