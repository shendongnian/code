	class Employee:IEquatable<int>
    {
        public int Id { get; set; }
        public bool Equals(int other)
        {
            //no boxing
            return this.Id == other;
        }
        public override bool Equals(object obj)
        {
            if(obj is int)
            {   //boxing done. but this method will not be called if the param is int, as we have Equals method with int as param.
                return (int)obj==this.Id;
            }
            return base.Equals(obj);
        }
    }
	
