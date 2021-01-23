    Public string GetDocumentBinary()
        {
            string docPath = "DocumentPath";
            byte[] binarydata = File.ReadAllBytes(docPath);
            base64 = System.Convert.ToBase64String(binarydata, 0, binarydata.Length);
            return base64;
        }
