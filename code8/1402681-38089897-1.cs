        public class TestClass
        {
            public static string inputhistory1 = "value1";
            public static string inputhistory2 = "value2";
            public static string inputhistory3 = "value3";
            public static string inputhistory4 = "value4";
        }        
        var obj = new TestClass();
        var field = typeof (TestClass).GetField("inputhistory1");
        //use as below
        Console.WriteLine(field.GetValue(obj));
