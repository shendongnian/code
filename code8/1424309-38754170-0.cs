    public void addClass(ushort ID,ushort someSubClassType)
    {
       ClassList.Add(ID,ClassFacroty.Create(someSubClassType));
    }
    
    static class ClassFacroty
    {
         static ParentClass Create(ushort type)
         {
               // Create specific sub type base on type
         }
    }
