    [Serializable]
    public partial class ParkingAreaEFEntity
    {
        public ParkingAreaEFEntity()
        {
            CommonConstructor();
        }
        private void CommonConstructor()
        {
            //this.MyEmployees = new List<EmployeeEFEntity>();
        }
        public virtual Guid ParkingAreaUUID { get; set; }
        public virtual string ParkingAreaName { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual ICollection<EmployeeEFEntity> MyEmployees { get; set; }
        public virtual void AddEmployee(EmployeeEFEntity emp)
        {
            if (!emp.MyParkingAreas.Contains(this))
            {
                emp.MyParkingAreas.Add(this);
            }
            if (!this.MyEmployees.Contains(emp))
            {
                this.MyEmployees.Add(emp);
            }
        }
        public virtual void RemoveEmployee(EmployeeEFEntity emp)
        {
            if (emp.MyParkingAreas.Contains(this))
            {
                emp.MyParkingAreas.Remove(this);
            }
            if (this.MyEmployees.Contains(emp))
            {
                this.MyEmployees.Remove(emp);
            }
        }
