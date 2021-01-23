	public static async Task Copy(string src, string dest)
	{
		await Task.Run(() => {
			System.IO.File.Copy(src, dest);
		});
	}
