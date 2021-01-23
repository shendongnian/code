    string cCsv = oResponse.fileCSV;
    using (BinaryWriter bw = new BinaryWriter(File.Create("test.zip")))
    {
        bw.Write(System.Text.Encoding.UTF8.GetBytes(cCsv));
    }
