    public void addClass(ushort ID,ushort someSubClassType)
    {
       ClassList.Add(ID,ClassFactory.Create(someSubClassType));
    }
    
    static class ClassFactory
    {
         static ParentClass Create(ushort type)
         {
               // Create specific sub type base on type
               if (type == 1)
               {
                     return new SubType1();
               }
         }
    }
