    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Text;
    
    var s =  @"class M
    {
        public void P() { }
    }";
    var text = SourceText.From(s);
    var lineIndex = 2;
    var lineSpan = text.Lines[lineIndex].Span;
    var tree = SyntaxFactory.ParseSyntaxTree(text);
    var node = tree.GetRoot().FindNode(lineSpan);
    // or if you want a all nodes related to the span
    var node = tree.GetRoot().DescendantNodesAndSelf(lineSpan);
