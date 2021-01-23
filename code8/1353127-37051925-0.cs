    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
    using (Stream responseStream = response.GetResponseStream())
    {
        if (responseStream != null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                responseStream.CopyTo(ms);
                streamInByte = ms.ToArray();
            }
        }
    }
    
    using (TextReader tr = new StreamReader(new MemoryStream(streamInByte), Encoding.Default))
    {
        using (CsvReader csv = new CsvReader(tr))
        {
            // The value used to escape fields that contain a delimiter, quote, or line ending.
            // csv.Configuration.Quote = '"';
            if (csvUpload.IncludeInvoice) csv.Configuration.RegisterClassMap<PacketUploadInvoiceMasterMap>();
            else csv.Configuration.RegisterClassMap<PacketUploadBasicMasterMap>();
    
            // Remove white space from header
            csv.Configuration.TrimHeaders = true;
    
            IEnumerable<PacketUploadMaster> records = csv.GetRecords<PacketUploadMaster>().ToList();
    
            pumResults = records.ToList();
        }
    }
