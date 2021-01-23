    $ csharp
    Mono C# Shell, type "help;" for help
    
    Enter statements below.
    csharp> public static class Foo {
          >  
          > public static void SomeMethod () {
          >         int x = 0;
          >         Action bob = () => {x += 2;};
          >         bob();
          >         x += 1;
          >         bob();
          >         Console.WriteLine(x);
          >     }
          >  
          > }
    csharp> Foo.SomeMethod();
    5
