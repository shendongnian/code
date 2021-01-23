       public void Example(){
           dynamic instance = 
                CompileSource("namespace Test{public class DynamicCompile{ /*method*/}}")
                .TryLoadCompiledType("Test.DynamicCompile");
            //can now call methods on 'instance'
       }
    
