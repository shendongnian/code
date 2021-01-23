        public static Encoding GetEncoding(byte[4] bom)
        {
            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }
        async System.Threading.Tasks.Task MyMethod()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            StorageFile file = await openPicker.PickSingleFileAsync();
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            DataReader reader = DataReader.FromBuffer(buffer);
            byte[] fileContent = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(fileContent);
            string text = GetEncoding(new byte[4] {fileContent[0], fileContent[1], fileContent[2], fileContent[3] }).GetString(fileContent);
            txt.Document.SetText(Windows.UI.Text.TextSetOptions.None, text);
            //.. 
        }
