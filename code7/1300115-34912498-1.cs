using (
    IsolatedStorageFile isoFile =
        IsolatedStorageFile.GetStore(
            IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly,
            null, null))
{
    IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("LaptopInfo.txt",
        FileMode.Append, FileAccess.Write, isoFile);
    using (StreamWriter writer = new StreamWriter(isoStream))
    {
        writer.WriteLine("Data");
    }
    WriteServiceInfo("data written to isolated storage");
    isoFile.Close();
}
