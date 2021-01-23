    .class public auto ansi beforefieldinit Test extends [mscorlib]System.Object
    {
      .method public hidebysig specialname rtspecialname instance void .ctor () cil managed 
      {
        ldarg.0
        call instance void [mscorlib]System.Object::.ctor()
        ret
      }
      .method public final hidebysig virtual instance string ToString () cil managed 
      {
        ldstr "a"
        ret
      }
    }
    .class public auto ansi beforefieldinit Test2 extends Mnemosyne.Test
    {
      .method public hidebysig specialname rtspecialname instance void .ctor () cil managed 
      {
        IL_0000: ldarg.0
        IL_0001: call instance void Mnemosyne.Test::.ctor()
        IL_0006: ret
      }
      .method public hidebysig virtual instance string ToString () cil managed 
      {
        ldstr ""
        ret
      }
    }
