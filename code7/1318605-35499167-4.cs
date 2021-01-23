    public class Quarter
    {
        // properties and constructor ommitted
        public override bool Equals(object other)
        {
            if (!(other is Quarter))
            {
                return false;
            }
            var quarter = (Quarter)other;
            return quarter.Year == Year && quarter.Quarter == quarter;
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                // The two hard-coded digits below should be primes,
                // uniquely chosen per type (so no two types you define
                // use the same primes).
                int hash = (int) 2166136261;
                // Suitable nullity checks etc, of course :)
                hash = hash * 16777619 ^ Quarter.GetHashCode();
                hash = hash * 16777619 ^ Year.GetHashCode();
                return hash;
            }
        }
    }
