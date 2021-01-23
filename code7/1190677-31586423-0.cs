    // Decompiled with JetBrains decompiler
    // Type: Program
    // Assembly: test, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
    // MVID: D26FF17C-3FD8-4920-BEFC-ED98BC41836A
    // Assembly location: C:\temp\test.exe
    // Compiler-generated code is shown
    
    using System;
    using System.Runtime.CompilerServices;
    
    internal static class Program
    {
      private static void Main()
      {
        Program.\u003C\u003Ec__DisplayClass1 cDisplayClass1 = new Program.\u003C\u003Ec__DisplayClass1();
        cDisplayClass1.x = 1;
        // ISSUE: method pointer
        Action action = new Action((object) cDisplayClass1, __methodptr(\u003CMain\u003Eb__0));
        cDisplayClass1.x = 3;
        action();
        Console.WriteLine(cDisplayClass1.x);
      }
    
      [CompilerGenerated]
      private sealed class \u003C\u003Ec__DisplayClass1
      {
        public int x;
    
        public \u003C\u003Ec__DisplayClass1()
        {
          base.\u002Ector();
        }
    
        public void \u003CMain\u003Eb__0()
        {
          Console.WriteLine(this.x);
          this.x = 2;
        }
      }
    }
