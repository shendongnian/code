	public interface IFileIO
	{
		IObservable<Unit> WriteTextAsync(IsolatedStorageFileStream storageFile, string text);
		IObservable<string> ReadTextAsync(IsolatedStorageFileStream storageFile);
	}
