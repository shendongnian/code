    public static class Program
    {
        [STAThread]
        static void Main()
        {
            NeedsTesting target = new NeedsTesting();
            DoTest( target );
        }
        private static void DoTest(NeedsTesting target)
        {
            Type type = typeof( NeedsTesting );
            PropertyInfo[] properties;
            int count = 0;
                        
            properties = type.GetProperties();
            foreach( PropertyInfo property in properties )
            {
                if( property.Name.StartsWith( "Group" ) )
                {
                    count++;
                    TestProperty( target, property );
                }
            }
            if( count != 5 )
            {
                VerifyEquals( false, true, "Did not find all 5 properties to test" );
            }
        }
        private static void TestProperty( NeedsTesting target, PropertyInfo property )
        {
            bool result;
            property.SetValue( target, true );
            result = (bool)property.GetValue( target );
            VerifyEquals( result, true, string.Format("Property '{0}' failed to retain a 'true' value.", property.Name ) );
            property.SetValue( target, false );
            result = (bool)property.GetValue( target );
            VerifyEquals( result, false, string.Format( "Property '{0}' failed to retain a 'false' value.", property.Name ) );
        }
        private static void VerifyEquals( bool left, bool right, string message )
        {
            if( left != right )
            {
                throw new Exception(
                     string.Format(
                        "Unit test failed - values were not equal:\r\n" +
                        "   left: {0}\r\n" +
                        "  right: {1}\r\n" +
                        "Message:\r\n" +
                        "{2}",
                        left,
                        right,
                        message
                    )
                );
            }
        }
    }
    public class NeedsTesting
    {
        private bool groupEValue;
        public bool GroupA { get; set; }
        public bool GroupB { get; set; }
        public bool GroupC { get; set; }
        public bool GroupD { get; set; }
        public bool GroupE
        {
            get
            {
                return this.groupEValue;
            }
            set
            {
                // Oops, this one is broken.
                value = false;
            }
        }
    }
