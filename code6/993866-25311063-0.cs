    public string SelectedThing
    {
        get { return string.Format("{0},{1}", ID, Discriminator); }
        set
        {
            if (value != null)
            {
                var parts = value.Split(',');
                if (parts.Length == 2)
                {
                    Int32.TryParse(parts[0], out ID);
                    Boolean.TryParse(parts[1], out Discriminator);
                }
            }
        }
    }
