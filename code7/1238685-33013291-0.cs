    const string code = @"public class Example {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public DateTime CurrentDate { get; set; }
    }";
    var syntaxTree = new CSharpParser().Parse(code, "program.cs");
    var listOfPropertiesNames = syntaxTree.Children
        .SelectMany(astParentNode => astParentNode.Children)
        .OfType<PropertyDeclaration>()
        .Select(astPropertyNode => astPropertyNode.Name)
        .ToList();
