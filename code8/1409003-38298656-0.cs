        static void Main(string[] args)
        {
            var code = @"
    using System;
    namespace ConsoleApplication1
    {
        class TypeName
        {   
             public int Add(int x, int y) 
             {
                 return x+y;
             }
         }
    }";
            var st = SourceText.From(code);
            var sf = SyntaxFactory.ParseSyntaxTree(st);
            
            var span = sf.GetText().Lines[9].Span;
            var nodes = sf.GetRoot().DescendantNodes().Where(x => x.Span.IntersectsWith(span));
            
            Console.WriteLine(nodes.Last().ToString());
            Console.ReadKey();
        }
