        var myRewriter = new MyRewriter();
        string code = "";
        using (StreamReader sr = new StreamReader("Program.cs"))
        {
            code = sr.ReadToEnd();
        }
        var tree = CSharpSyntaxTree.ParseText(code);
        var node = tree.GetRoot();
        
        using(StreamWriter sw = new StreamWriter("Program.cs"))
        {
            sw.Write(myRewriter.Visit(node));
        }
