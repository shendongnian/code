    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Type GetCallerType()
      int skipFrames = 2; //Assumes that you are calling this from the method being invoked by the caller. Add stack frames to skip for each method removed, and make sure each one is marked with [MethodImpl(MethodImplOptions.NoInlining)]
      Type declaringType;
      do
      {
        MethodBase method = new StackFrame(skipFrames, false).GetMethod();
        declaringType = method.DeclaringType;
        skipFrames++;
      } while (declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase));
      return declaringType;
    }
