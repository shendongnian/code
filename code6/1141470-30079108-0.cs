	public interface IMyLibrary
	{
		Task DoExternalWorkAsync();
	}
	public class MyStaticLibrary : IMyLibrary
	{
		public async Task DoExternalWorkAsync(string sourcePath, MyModel model)
		{
			return await MyStaticLibrary.DoExternalWorkAsync(sourcePath, model);
		}
	}
