    public static object Eval(string booleanExpression) {
    
      var c = new Microsoft.CSharp.CSharpCodeProvider();
      var icc = c.CreateCompiler();
      var cp = new System.CodeDom.Compiler.CompilerParameters();
    
      cp.CompilerOptions = "/t:library";
      cp.GenerateInMemory = true;
    
      StringBuilder sb = new StringBuilder("");
      sb.Append("using System;\n" );
    
      sb.Append("namespace BooleanEvaluator{ \n");
      sb.Append("public class BooleanEvaluator{ \n");
      sb.Append("public bool Evaluate(){\n");
      sb.Append("return "+booleanExpression+"; \n");
      sb.Append("} \n");
      sb.Append("} \n");
      sb.Append("}\n");
    
      var cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
    
      System.Reflection.Assembly a = cr.CompiledAssembly;
      object o = a.CreateInstance("BooleanEvaluator.BooleanEvaluator");
    
      Type t = o.GetType();
      MethodInfo mi = t.GetMethod("Evaluate");
    
      return (bool) mi.Invoke(o, null);
    }
