    private class FolderDetails
    {
        public string PropertyGroupName { get; set; }
        public string ProjFiles { get; set; }
        public override string ToString()
        {
            return string.Format("{0}:{1}", this.PropertyGroupName, this.ProjFiles);
        }
    }
