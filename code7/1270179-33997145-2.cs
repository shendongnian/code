    public class OneTwoTypeResolver : TypeConverter<One, Two>
    {
        protected override Two ConvertCore(One source)
        {
            Two two = new Two {List1 = new List<string>()};
            if (source.S1 != null)
                two.List1.Add(source.S1);
            if (source.S2 != null)
                two.List1.Add(source.S2);
            if (source.S3 != null)
                two.List1.Add(source.S3);
            if (source.S4 != null)
                two.List1.Add(source.S4);
            return two;
        }
    }
