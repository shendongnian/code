    public partial class Zone
    {
        protected bool Equals(Zone other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
    
            if (ReferenceEquals(other, this))
            {
                return true;
            }
    
            return string.Equals(CityCode, other.CityCode) &&
                   string.Equals(City, other.City) &&
                   string.Equals(Province, other.Province) &&
                   ProvinceCode == other.ProvinceCode;
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (CityCode != null ? CityCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (City != null ? City.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Province != null ? Province.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ ProvinceCode.GetHashCode();
                return hashCode;
            }
        }
    
        public static bool operator ==(Zone left, Zone right)
        {
            return Equals(left, right);
        }
    
        public static bool operator !=(Zone left, Zone right)
        {
            return !Equals(left, right);
        }
    
        public override bool Equals(object obj)
        {
            return Equals(obj as Zone);
        }
    }
    
