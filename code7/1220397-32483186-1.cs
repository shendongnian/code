    IL_0000:  nop         
    IL_0001:  newobj      System.Collections.Generic.Dictionary<System.Int32,System.String>..ctor
    IL_0006:  stloc.1     
    IL_0007:  ldloc.1     
    IL_0008:  ldc.i4.1    
    IL_0009:  ldstr       "one"
    IL_000E:  callvirt    System.Collections.Generic.Dictionary<System.Int32,System.String>.Add
    IL_0013:  nop         
    IL_0014:  ldloc.1     
    IL_0015:  ldc.i4.2    
    IL_0016:  ldstr       "two"
    IL_001B:  callvirt    System.Collections.Generic.Dictionary<System.Int32,System.String>.Add
    IL_0020:  nop         
    IL_0021:  ldloc.1     
    IL_0022:  stloc.0     // dictionary
    IL_0023:  nop         
    IL_0024:  ldloc.0     // dictionary
    IL_0025:  callvirt    System.Collections.Generic.Dictionary<System.Int32,System.String>.get_Values
    IL_002A:  callvirt    System.Collections.Generic.Dictionary<System.Int32,System.String>+ValueCollection.GetEnumerator
    IL_002F:  stloc.2     
    IL_0030:  br.s        IL_0043
    IL_0032:  ldloca.s    02 
    IL_0034:  call        System.Collections.Generic.Dictionary<System.Int32,System.String>+ValueCollection+Enumerator.get_Current
    IL_0039:  stloc.3     // item
    IL_003A:  nop         
    IL_003B:  ldloc.3     // item
    IL_003C:  call        System.Console.WriteLine
    IL_0041:  nop         
    IL_0042:  nop         
    IL_0043:  ldloca.s    02 
    IL_0045:  call        System.Collections.Generic.Dictionary<System.Int32,System.String>+ValueCollection+Enumerator.MoveNext
    IL_004A:  brtrue.s    IL_0032
    IL_004C:  leave.s     IL_005D
    IL_004E:  ldloca.s    02 
    IL_0050:  constrained. System.Collections.Generic.Dictionary<,>+ValueCollection.Enumerator
    IL_0056:  callvirt    System.IDisposable.Dispose
    IL_005B:  nop         
    IL_005C:  endfinally  
    IL_005D:  ret         
