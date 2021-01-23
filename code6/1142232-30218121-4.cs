    public partial class TestDb : LinqToDB.Data.DataConnection
    {
    	public ITable<Directory>    Directories   { get { return this.GetTable<Directory>(); } }
    	public ITable<File>         Files         { get { return this.GetTable<File>(); } }
    }
    
    [Table(Schema="dbo", Name="Directory")]
    public partial class Directory
    {
    	[PrimaryKey, Identity] public int    ID   { get; set; } // int
    	[Column,     NotNull ] public string Path { get; set; } // varchar(max)
    
    	#region Associations
    
    	/// <summary>
    	/// FK_File_Directory_BackReference
    	/// </summary>
    	[Association(ThisKey="ID", OtherKey="DirectoryID", CanBeNull=true, IsBackReference=true)]
    	public List<File> Files { get; set; }
    
    	#endregion
    }
    
    [Table(Schema="dbo", Name="File")]
    public partial class File
    {
    	[PrimaryKey, Identity] public int    ID          { get; set; } // int
    	[Column,     NotNull ] public int    DirectoryID { get; set; } // int
    	[Column,     NotNull ] public string Name        { get; set; } // varchar(max)
    
    	#region Associations
    
    	/// <summary>
    	/// FK_File_Directory
    	/// </summary>
    	[Association(ThisKey="DirectoryID", OtherKey="ID", CanBeNull=false, KeyName="FK_File_Directory", BackReferenceName="Files")]
    	public Directory Directory { get; set; }
    
    	#endregion
    }
