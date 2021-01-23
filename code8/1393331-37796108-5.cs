    [Serializable]
    public partial class EmployeeEFEntity
    {
    public EmployeeEFEntity()
    {
        CommonConstructor();
    }
    private void CommonConstructor()
    {
        //this.MyParkingAreas = new List<ParkingAreaEFEntity>();
    }
    //EF Tweaks
    public virtual Guid? ParentDepartmentUUID { get; set; }
    public virtual Guid? EmployeeUUID { get; set; }
    public virtual byte[] TheVersionProperty { get; set; }
    public virtual DepartmentEFEntity ParentDepartment { get; set; }
    public virtual string SSN { get; set; }
    public virtual string LastName { get; set; }
    public virtual string FirstName { get; set; }
    public virtual DateTime CreateDate { get; set; }
    public virtual DateTime HireDate { get; set; }
    public virtual ICollection<ParkingAreaEFEntity> MyParkingAreas { get; set; }
	public ParkingAreaEFEntity MyOneParkingAreaEFEntity {
		
		get 
		{
			return MyParkingAreas.FirstOrDefault();
		}
		set
		{
			/* check for more than one here */
			this.AddParkingArea(pa);
		}
	}
    public virtual void AddParkingArea(ParkingAreaEFEntity pa)
    {
        if (!pa.MyEmployees.Contains(this))
        {
            pa.MyEmployees.Add(this);
        }
        if (!this.MyParkingAreas.Contains(pa))
        {
            this.MyParkingAreas.Add(pa);
        }
    }
    public virtual void RemoveParkingArea(ParkingAreaEFEntity pa)
    {
        if (pa.MyEmployees.Contains(this))
        {
            pa.MyEmployees.Remove(this);
        }
        if (this.MyParkingAreas.Contains(pa))
        {
            this.MyParkingAreas.Remove(pa);
        }
    }
    public override string ToString()
    {
        return string.Format("{0}:{1},{2}", this.SSN, this.LastName, this.FirstName);
    }
