     public static async Task<StorageFile> EncryptStorageFileLocalUserAsync(this StorageFile FileForEncryption)
        {
            //"LOCAL = user"
            IBuffer data = await FileIO.ReadBufferAsync(FileForEncryption);
            IBuffer SecuredData = await DataProtectionStream("LOCAL = user", data);
            var  EncryptedFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(
              "EncryptedFile" + FileForEncryption.FileType, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBufferAsync(EncryptedFile, SecuredData);
            return EncryptedFile;
           // Reporting.DisplayMessage( "File encryption successfull. File stored at " + EncryptedFile.Path + "\n\n");
        }
        public static async Task<StorageFile> DecryptStorageFileLocalUserAsync(this StorageFile EncryptedFile)
        {
            IBuffer data = await FileIO.ReadBufferAsync(EncryptedFile);
            IBuffer UnSecuredData = await DataUnprotectStream(data);
             var DecryptedFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(
              "DecryptedFile" + EncryptedFile.FileType, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBufferAsync(DecryptedFile, UnSecuredData);
           // Reporting.DisplayMessage("File decryption successfull. File stored at " + DecryptedFile.Path + "\n\n");
            return DecryptedFile;
        }
