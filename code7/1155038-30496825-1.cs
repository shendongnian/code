        public override bool Equals(object obj)   
        {
            Skill newskill;
            newskill = (Skill)obj;
            return (obj.GetHashCode() == newskill.GetHashCode());
        }
        public override int GetHashCode()    
        {
            int temp = name.GetHashCode();
            return temp;
        }
