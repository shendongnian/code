        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using Microsoft.CodeAnalysis;
        using Microsoft.CodeAnalysis.CSharp;
        using Microsoft.CodeAnalysis.CSharp.Syntax;
        using Microsoft.CodeAnalysis.MSBuild;
        using System.Threading.Tasks;
        namespace Kardex.LC3xx.CreateApiDokumentation
        {
            //Patch to work with VS2013
            //  https://support.microsoft.com/en-us/kb/2971005
            class Program
            {
                private static void Main(string[] args)
                {
                    Run(args).Wait();
                    Console.ReadLine();
                }
                private async static Task Run(string[] args)
                {
                    var path = Path.GetDirectoryName(typeof (Program).Assembly.Location);
                    var sln = Path.Combine(path, "xxx.sln");
                    var workspace = MSBuildWorkspace.Create();
                    var solution = await workspace.OpenSolutionAsync(sln);
           
                    Project project = solution.Projects.First(x => x.Name == "bbbb");
                    var compilation = await project.GetCompilationAsync();
            
                    foreach (var @class in compilation.GlobalNamespace.GetNamespaceMembers().SelectMany(x=>x.GetMembers()))
                    {
                        Console.WriteLine(@class.Name);
                        Console.WriteLine(@class.ContainingNamespace.Name);
                    }
            
                    var classVisitor = new ClassVirtualizationVisitor();
                    foreach (var syntaxTree in compilation.SyntaxTrees)
                    {
                        classVisitor.Visit(syntaxTree.GetRoot());                
                    }
                    var classes = classVisitor.Classes;             
                }
                class ClassVirtualizationVisitor : CSharpSyntaxRewriter
                {
                    public ClassVirtualizationVisitor()
                    {
                        Classes = new List<ClassDeclarationSyntax>();
                    }
                    public List<ClassDeclarationSyntax> Classes { get; set; }
                    public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
                    {
                        node = (ClassDeclarationSyntax)base.VisitClassDeclaration(node);
                        Classes.Add(node); // save your visited classes
                        return node;
                    }
                }
            }
        }
