        public class MyCultureInfo : CultureInfo
        {
            public MyCultureInfo():base(CultureInfo.InvariantCulture.Name)
            {
            }
            public override DateTimeFormatInfo DateTimeFormat
            {
                get
                {
                    DateTimeFormatInfo myDateTimeFormatInfo = base.DateTimeFormat;
                    myDateTimeFormatInfo.PMDesignator = "p.m.";
                    myDateTimeFormatInfo.AMDesignator = "a.m.";
                    return myDateTimeFormatInfo;
                }
                set
                {
                    base.DateTimeFormat = value;
                }
            }
        }
        public static class MyFormat
        {
            public const string MyDateTimeFormat = "dd/MM/yyyy hh:mm:ss tt";
        }
        static int Main(string[] args)
        {
            var myStringDateValue = "11/05/2015 01:04:16 p.m.";
            var result = DateTime.ParseExact(myStringDateValue, MyFormat.MyDateTimeFormat, new MyCultureInfo());
        }
