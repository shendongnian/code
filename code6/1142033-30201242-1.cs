    public class EntityModelCacheKey : IDbModelCacheKey
    {
        private readonly int _hashCode;
        public EntityModelCacheKey(int hashCode)
        {
            _hashCode = hashCode;
        }
        public override bool Equals(object other)
        {
            if (other == null) return false;
            return other.GetHashCode() == _hashCode;
        }
        public override int GetHashCode()
        {
            return _hashCode;
        }
    }
