        private void dialogImportMsg_FileOk(object sender, CancelEventArgs e)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(dialogImportMsg.FileName, FileMode.Open)))
            {
                binaryStrLen = reader.ReadInt16();
                for (short x = 0; x < binaryStrLen; x++)
                {
                    binaryStr[x] = reader.ReadInt16();
                }
            }
        }
        private void butExport_Click(object sender, EventArgs e)
        {
            dialogExportMsg.ShowDialog();
        }
        private void dialogExportMsg_FileOk(object sender, CancelEventArgs e)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(dialogExportMsg.FileName, FileMode.OpenOrCreate)))
            {
                writer.Write(BitConverter.GetBytes(binaryStrLen));
                for (int x = 0; x < binaryStrLen; x++)
                {
                    writer.Write(BitConverter.GetBytes(binaryStr[x]));
                }
            }
        }
