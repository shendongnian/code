    internal class SomeImpossibleName<M_SType, M_LType>
    {
      private readonly M_SType _m_s;
      private readonly M_LType _m_l;
      public SomeImpossibleName(M_SType s, M_LType l)
      {
        _m_s = s;
        _m_l = l;
      }
      public M_SType m_s
      {
        get { return _m_s; }
      }
      public M_LType m_l
      {
        get { return _m_l; }
      }
      public override bool Equals(object value)
      {
        var compareWith = value as SomeImpossibleName<M_SType, M_LType>;
        if(compareWith == null)
          return false;
        if(!EqualityComparer<M_SType>.Default.Equals(_m_s, compareWith._m_s))
          return false;
        return EqualityComparer<M_LType>.Default.Equals(_m_l, compareWith._m_l);
      }
      public override int GetHashCode()
      {
        unchecked
        {
          return (-143687205 * -1521134295 + EqualityComparer<M_SType>.Default.GetHashCode(_m_s))
          * 1521134295 + EqualityComparer<M_LType>.Default.GetHashCode(_m_l);
        }
      }
      public override string ToString()
      {
        return new StringBuilder().Append("{ m_s = ")
          .Append((object)_m_s)
          .Append(", m_l = ")
          .Append((object)_m_l)
          .Append(" }")
          .ToString();
      }
    }
