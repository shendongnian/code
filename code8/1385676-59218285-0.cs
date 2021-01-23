 csharp
public class RegionInfo
{
    public RegionDirectiveTriviaSyntax Begin;
    public EndRegionDirectiveTriviaSyntax End;
    public RegionInfo Parent;
    public List<RegionInfo> Children = new List<RegionInfo>();
    public string Name => this.Begin.EndOfDirectiveToken.ToFullString().Trim();
}
public static class CodeMutator
{   
    public static string ReplaceRegion(string existingCode, string regionName, string newCode)
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(existingCode);
        var region = CodeMutator.GetRegion(syntaxTree, regionName);
        if (region == null)
        {
            throw new Exception($"Cannot find region named {regionName}");
        }
        return 
            existingCode
                .Substring(0, region.Begin.FullSpan.End) +
            newCode +
            Environment.NewLine +
            existingCode
                .Substring(region.End.FullSpan.Start);
    }
    
    static RegionInfo GetRegion(SyntaxTree syntaxTree, string regionName) =>
        CodeMutator.GetRegions(syntaxTree)
            .FirstOrDefault(x => x.Name == regionName);
    
    static List<RegionInfo> GetRegions(SyntaxTree syntaxTree)
    {
        var directives = syntaxTree
            .GetRoot()
            .DescendantNodes(descendIntoTrivia: true)
            .OfType<DirectiveTriviaSyntax>()
            .Select(x => (x.GetLocation().SourceSpan.Start, x))
            .OrderBy(x => x.Item1)
            .ToList();
        var allRegions = new List<RegionInfo>();
        RegionInfo parent = null;
        foreach (var directive in directives)
        {
            if (directive.Item2 is RegionDirectiveTriviaSyntax begin)
            {
                var next = new RegionInfo() {Begin = begin, Parent = parent};
                allRegions.Add(next);
                parent?.Children.Add(next);
                parent = next;
            }
            else if (directive.Item2 is EndRegionDirectiveTriviaSyntax end)
            {
                if (parent == null)
                {
                    Log.Error("Unmatched end region");
                }
                else
                {
                    parent.End = end;
                    parent = parent.Parent;
                }
            }
        }
        return allRegions;
    }
}
