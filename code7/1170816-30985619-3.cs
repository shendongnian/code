    private static IEnumerable<Type> GetUsedTypes(Type type, MethodInfo mi)
    {
      var body = mi.GetMethodBody();
      if(body == null) // not managed code
        yield break;
      var cil = body.GetILAsByteArray();
      for(int idx = 0; idx < cil.Length; ++idx)
      {
        switch(cil[idx])
        {
          case 0x73: // newobj
            int token = cil[++idx];
            token |= (int)cil[++idx] << 8;
            token |= (int)cil[++idx] << 16;
            token |= (int)cil[++idx] << 24;
            yield return type.Module.ResolveMethod(token).DeclaringType;
            break;
          /* TODO: Other opcodes that deal with types */
        }
      }
    }
