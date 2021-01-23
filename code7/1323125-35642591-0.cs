    public class MyCustomAttribute : Attribute
    {
        public MyCustomAttribute()
        {
            if (GetType().CustomAttributes.Count(attr => attr.AttributeType == typeof (MyCustomClassAttribute)) < 1) 
            {
                 throw new Exception("Needs parent attribute") //Insert Postsharp method of raising compile time error here
            }
