    public void Mul(ref BigIntegerBuilder reg1, ref BigIntegerBuilder reg2) {
      ...
      if (reg1._iuLast == 0) {
        if (reg2._iuLast == 0)
          Set((ulong)reg1._uSmall * reg2._uSmall);
        else {
          ...
        }
      }
      else if (reg2._iuLast == 0) {
        ...
      }
      else {
        ...
      }
    }
