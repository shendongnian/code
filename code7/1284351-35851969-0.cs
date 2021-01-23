    public class Globals
    {
        public ObjType obj;
    }
    …
    CSharpScript.EvaluateAsync(
        "obj.SomeFunc(x => x.Username)", globals: new Globals { obj = obj });
