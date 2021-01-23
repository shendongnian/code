    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class folders
    {
    
        private foldersFolder[] folderField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Folder")]
        public foldersFolder[] Folder
        {
            get
            {
                return this.folderField;
            }
            set
            {
                this.folderField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class foldersFolder
    {
    
        private string folder_nameField;
    
        private byte number_of_filesField;
    
        private foldersFolderFile[] fileField;
    
        /// <remarks/>
        public string Folder_name
        {
            get
            {
                return this.folder_nameField;
            }
            set
            {
                this.folder_nameField = value;
            }
        }
    
        /// <remarks/>
        public byte Number_of_files
        {
            get
            {
                return this.number_of_filesField;
            }
            set
            {
                this.number_of_filesField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("File")]
        public foldersFolderFile[] File
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class foldersFolderFile
    {
    
        private string file_nameField;
    
        private uint file_size_in_bytesField;
    
        /// <remarks/>
        public string File_name
        {
            get
            {
                return this.file_nameField;
            }
            set
            {
                this.file_nameField = value;
            }
        }
    
        /// <remarks/>
        public uint File_size_in_bytes
        {
            get
            {
                return this.file_size_in_bytesField;
            }
            set
            {
                this.file_size_in_bytesField = value;
            }
        }
    }
