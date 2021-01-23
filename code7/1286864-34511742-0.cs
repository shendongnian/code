    string pfxCertificate = null;
    string pfxPassword = "";    
    
    FileOpenPicker filePicker = new FileOpenPicker();
    filePicker.FileTypeFilter.Add(".pfx");
    filePicker.CommitButtonText = "Open";
    
    try
    {
        StorageFile file = await filePicker.PickSingleFileAsync();
        if (file != null)
        {
            // file was picked and is available for read
            // try to read the file content
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            using (DataReader dataReader = DataReader.FromBuffer(buffer))
            {
                byte[] bytes = new byte[buffer.Length];
                dataReader.ReadBytes(bytes);
                // convert to Base64 for using with ImportPfx
                pfxCertificate = System.Convert.ToBase64String(bytes);
            }
    
            await CertificateEnrollmentManager.UserCertificateEnrollmentManager.ImportPfxDataAsync(
                pfxCertificate,
                pfxPassword,
                ExportOption.NotExportable,
                KeyProtectionLevel.NoConsent,
                InstallOptions.None,
                "Test");
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
