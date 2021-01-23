    void Main()
    {
        var method = typeof(Test).GetMethod("Method");
        
        var d = new DynamicMethod("xx", typeof(void), new Type[0]);
        var il = d.GetILGenerator();
        il.Emit(OpCodes.Ldnull);
        il.Emit(OpCodes.Call, method);
        il.Emit(OpCodes.Ret);
        
        var a = (Action)d.CreateDelegate(typeof(Action));
        a();
    }
    
    public class Test
    {
        public void Method()
        {
            this.Dump();
        }
    }
