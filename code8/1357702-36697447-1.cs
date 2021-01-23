    public Location()
    {
        this.Departments = new HashSet<Department>();
    }
    public virtual ICollection<Department> Departments { get; set; }
