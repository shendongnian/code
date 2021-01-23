    IL_0000:  nop         
    IL_0001:  newobj      System.Collections.Generic.List<System.String>..ctor
    IL_0006:  stloc.0     // x
    IL_0007:  nop         
    IL_0008:  ldloc.0     // x
    IL_0009:  callvirt    System.Collections.Generic.List<System.String>.GetEnumerator
    IL_000E:  stloc.1     
    IL_000F:  br.s        IL_001B
    IL_0011:  ldloca.s    01 
    IL_0013:  call        System.Collections.Generic.List<System.String>+Enumerator.get_Current
    IL_0018:  stloc.2     // y
    IL_0019:  nop         
    IL_001A:  nop         
    IL_001B:  ldloca.s    01 
    IL_001D:  call        System.Collections.Generic.List<System.String>+Enumerator.MoveNext
    IL_0022:  brtrue.s    IL_0011
    IL_0024:  leave.s     IL_0035
    IL_0026:  ldloca.s    01 
    IL_0028:  constrained. System.Collections.Generic.List<>.Enumerator
    IL_002E:  callvirt    System.IDisposable.Dispose
    IL_0033:  nop         
    IL_0034:  endfinally  
    IL_0035:  ret   
   
