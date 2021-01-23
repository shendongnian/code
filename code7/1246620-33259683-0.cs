    public string Directory
    {
        get { 
            return String.IsNullOrWhiteSpace(this.SomeString) ? "unknown" : this.SomeString; 
        }
    }
