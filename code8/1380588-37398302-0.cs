    public ClientViewModel()
    {
        Id = Guid.NewGuid();
        this.Notes = new HashSet<NoteViewModel>();
    }
