    public override int GetHashCode()
    {
      unchecked
      {
        int hashCode = (_firstName != null ? _firstName.GetHashCode() : 0);
        hashCode = (hashCode*397) ^ (_lastName != null ? _lastName.GetHashCode() : 0);
        hashCode = (hashCode*397) ^ (_eMPID != null ? _eMPID.GetHashCode() : 0);
        return hashCode;
      }
    }
