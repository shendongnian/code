    void Main()
    {
        var constants =
            from fieldInfo in typeof(Test).GetFields()
            where (fieldInfo.Attributes & FieldAttributes.Literal) != 0
            select fieldInfo.Name;
        constants.Dump();
    }
    
    public class Test
    {
        public const int Value = 42;
        public static readonly int Field = 42;
    }
