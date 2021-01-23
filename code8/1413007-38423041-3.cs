     public static class MyVariableExampleClass{
        
       public static string globalVariable = "All functions in this class can see this variable";
    
       public static void FunctionOne(){
           string varibleForFunctionOne = globalVariable;
        }
        
       public static void FunctionTwo(){
           string varibleForFunctionOne = globalVariable;
       }
    }
