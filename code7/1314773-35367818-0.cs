    public string Tags { get; set; }
    [NotMapped]
    public List<string> TagsList
    {
        get
        {
            return !String.IsNullOrWhiteSpace(Tags)
                ? Tags.Replace("[", "").Replace("]", "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                : new List<string>();
        }
        set
        {
            Tags = value != null
                ? String.Join(",", value.Select(tag => "[" + tag + "]"))
                : null;
        }
    }
