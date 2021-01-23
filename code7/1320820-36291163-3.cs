    class Program
    {
    	static void Main(string[] args)
    	{
    		CSScript.EvaluatorConfig.DebugBuild = true;
    		CSScript.EvaluatorConfig.Engine = EvaluatorEngine.CodeDom;
    
    		Console.WriteLine("Debug on = " + CSScript.Evaluator.DebugBuild);
    
    		dynamic script = CSScript.Evaluator
    					 .LoadCode(@"using System;
                                     public class Script
                                     {
                                         public int Sum(int a, int b)
                                         {
                                             try{
                                             throw new Exception();}
                                             catch(Exception ex){
                                               Console.WriteLine(ex.StackTrace);
                                             }
                                             return a+b;
                                         }
                                     }");
    		int result = script.Sum(1, 2);
    		Console.WriteLine(result);
    		Console.ReadLine();
    	}
    }
