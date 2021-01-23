    public IList<bool> Flags
    {
        get
        {
            try
            {
                return self.Element("Flags")
                    .Elements()
                    .Select(x => (bool)x)
                    .ToList();
            }
            catch
            {
                return new bool[] { }.ToList();
            }
        }
        set
        {
            XElement flags = self.GetElement("Flags");
            flags.RemoveAll();
            flags.Add(value.Select(b => new XElement("flag", b)));
        }
    }
