    public class TypeBase 
    {
       public virtual string Name { get; set; }
    }
    public class Type1 : TypeBase
    {
    }
    public class Type2 : TypeBase
    {
    }
    foreach (var myobject in MyList)
    {
        if (myObject.GetType().IsArray)
        {
            object[] array = (object[]) myObject;
            TypeBase[] yourArray = array.Cast<TypeBase>();
            //use the properties and methods of TypeBase instead of Type1 and Type2
            //mark the methods and properties in TypeBase as virtual and
            //override them on Type1 and Type2 if needed
        }
    }
