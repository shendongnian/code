    bool flag = base.IsPointer || this.IsEnum || base.IsPrimitive;
    if (flag)
    {
      ...
      if (RuntimeType.CanValueSpecialCast(valueType, this))
      {
        ...
      }
    }
