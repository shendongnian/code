	class Post : IDataErrorInfo
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Markdown { get; set; }
		public string Error
		{
			get { throw new NotImplementedException(); }
		}
		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case "Title":
						if (string.IsNullOrEmpty(Title))
							return "Title is required";
						break;
					case "Markdown":
						if (string.IsNullOrEmpty(Markdown))
							return "Markdown is required";
						break;
				}
				return "";
			}
		}
	}
