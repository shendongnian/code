    public override bool Equals(System.Object obj)
    {
        if (obj == null)
        {
            return false;
        }
        WorkingFileItem item = obj as WorkingFileItem;
        return Equals(item);
    }
    public bool Equals(WorkingFileItem item)
    {
        if (item == null)
        {
            return false;
        }
        return (Name == item.Name) && (FilePath == item.FilePath);
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ FilePath.GetHashCode();
    }
