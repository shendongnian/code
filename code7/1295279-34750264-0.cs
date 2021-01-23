    public MyStaticWrapper : IMyStaticWrapper
    {
       public void SomeMethod(string something)
       {
          MyStatic.SomeMethod(something); 
       }
    }
