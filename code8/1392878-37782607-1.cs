    static class Program
    {
        static void Main(string[] args)
        {
            SomeMethod("Hello, World!!!");
            Type testType = typeof(Program);
            FieldInfo[] fieldInfo = testType.GetFields();
            MethodInfo methodInfo = testType.GetMethod("SomeMethod");
            Console.WriteLine("Parameter type:{0}", TypeOfField(fieldInfo, methodInfo, "sampleString"));
            Console.WriteLine("Parameter type:{0}", TypeOfField(fieldInfo, methodInfo, "classField"));
            Console.WriteLine("Parameter type:{0}", TypeOfField(fieldInfo, methodInfo, "helloWorld"));
            Console.WriteLine("Parameter type:{0}", TypeOfField(fieldInfo, methodInfo, "nonexistentVariable"));
        }
        public static string classField = "Hello, World!!!";
        public static void SomeMethod(string sampleString)
        {
            string helloWorld = sampleString;
        }
        public static string TypeOfField(FieldInfo[] fieldInfo, MethodInfo methodInfo, string fieldName)
        {
            if (IsClassField(fieldInfo, fieldName))
            {
                return "Class Field";
            }
            else if (IsParameter(methodInfo, fieldName))
            {
                return "Parameter";
            }
            else
            {
                return "Cannot determine";
            }
        }
        private static bool IsClassField(FieldInfo[] fieldInfo, string classFieldName)
        {
            bool isClassField = false;
            foreach (var item in fieldInfo)
            {
                if (item.Name == classFieldName)
                {
                    isClassField = true;
                    break;
                }
            }
            return isClassField;
        }
        private static bool IsParameter(MethodInfo methodInfo, string parameterName)
        {
            bool isParameter = false;
            ParameterInfo[] paramInfo = methodInfo.GetParameters();
            foreach (var item in paramInfo)
            {
                if (item.Name == parameterName)
                {
                    isParameter = true;
                    break;
                }
            }
            return isParameter;
        }
    }
