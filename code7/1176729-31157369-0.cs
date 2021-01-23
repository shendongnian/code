    public static class CustomReflectionHelpers
    {
        public static String CreateUniqueNameFromSignature(this MethodInfo mi)
        {
            String signatureString = String.Join(",", mi.GetParameters().Select(p => p.ParameterType.Name).ToArray());
            String returnTypeName = mi.ReturnType.Name;
            // returns a string like this: "YourSolution.YourProject.YourClass:YourMethod(Param1TypeName,...,ParamNTypeName):ReturnTypeName
            return String.Format("{0}:{1}({2}):{3}", mi.DeclaringType.FullName, mi.Name, signatureString, returnTypeName);
        }
    }
