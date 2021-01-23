    public static class CustomReflectionHelpers
    {
        public static String CreateUniqueName(this MethodInfo mi)
        {
            String signatureString = String.Join(",", mi.GetParameters().Select(p => p.ParameterType.Name).ToArray());
            String returnTypeName = mi.ReturnType.Name;
            if (mi.IsGenericMethod)
            {
                String typeParamsString = String.Join(",", mi.GetGenericArguments().Select(g => g.AssemblyQualifiedName).ToArray());
                
                // returns a string like this: "Assembly.YourSolution.YourProject.YourClass:YourMethod(Param1TypeName,...,ParamNTypeName):ReturnTypeName
                return String.Format("{0}:{1}<{2}>({3}):{4}", mi.DeclaringType.AssemblyQualifiedName, mi.Name, typeParamsString, signatureString, returnTypeName);
            }
            return String.Format("{0}:{1}({2}):{3}", mi.DeclaringType.AssemblyQualifiedName, mi.Name, signatureString, returnTypeName);
        }
    }
