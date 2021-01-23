	[Serializable]
	public class MyFileInfo
	{
		public string Name { get; set; }
		public long Length { get; set;}
		/// <summary>
		/// An empty ctor is needed for serialization.
		/// </summary>
		public MyFileInfo(){
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="test.MyFileInfo"/> class.
		/// </summary>
		/// <param name="fileInfo">File info.</param>
		public MyFileInfo(string path)
		{
			FileInfo fileInfo = new FileInfo (path);
			this.Length = fileInfo.Length;
			this.Name = fileInfo.Name;
			// TODO: add and initilize other members
		}
	}
