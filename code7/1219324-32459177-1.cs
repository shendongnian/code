        [DelimitedRecord(";")]
        [IgnoreEmptyLines]
        [IgnoreFirst()]
        public class TestRecord
        {
            //Mandatory
            [FieldNotEmpty]
            public string A;
            [FieldOptional]
            public string B;
            [FieldOptional]
            public string C;
        }
