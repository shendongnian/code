    public class Folder
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public virtual FolderSettings FolderSettings { get; set; }
		private ICollection<FolderSettings> _folders { get; set; }
		public ICollection<FolderSettings> Folders
		{
			get { return _folders ?? (_folders = new HashSet<FolderSettings>()); }
			set { _folders = value; }
		}
		private ICollection<File> _files { get; set; }
		public ICollection<File> Files
		{
			get { return _files ?? (_files = new HashSet<File>()); }
			set { _files = value; }
		}
	}
	public class File
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
	public class FolderSettings
	{
		[Key, ForeignKey("Folder")]
		public Guid FolderId { get; set; }
		public Folder Folder { get; set; }
		public virtual MVAppGroup AppGroup { get; set; }
		[ForeignKey("Group")]
		public Guid? GroupId { get; set; }
		public virtual MVAppGroup Group { get; set; }
	}
	public class MVAppGroup
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
	public class A : DbContext
	{
		public DbSet<Folder> Folders { get; set; }
		public DbSet<File> Files { get; set; }
		public DbSet<FolderSettings> FolderSettings { get; set; }
		public DbSet<MVAppGroup> MVAppGroups { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			using (var a = new A())
			{
				a.Folders.ToList();
			}
		}
	}
