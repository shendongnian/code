	 struct Employee : IEquatable<Employee>
    {
        public int Id { get; set; }
        public bool Equals(Employee other)
        {
            //no boxing not unboxing, direct compare
            return this.Id == other.Id;
        }
        public override bool Equals(object obj)
        {
            if(obj is Employee)
            {   //un boxing
                return ((Employee)obj).Id==this.Id;
            }
            return base.Equals(obj);
        }
    }
	
