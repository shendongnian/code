    class MyClass
    {
          static int value = ReadFromConifg();
          static int  ReadFromConifg()
          {...
               throw new ConfigMissingException();
          }
    }
   
