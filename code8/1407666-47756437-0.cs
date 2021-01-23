    using System;
    using System.Collections.Immutable;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Razor.Language;
    using Microsoft.AspNetCore.Razor.Language.Extensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    namespace RazorTemplate
    {
        class Program
        {
            static void Main(string[] args)
            {
                // customize the default engine a little bit
                var engine = RazorEngine.Create(b =>
                {
                    InheritsDirective.Register(b); // make sure the engine understand the @inherits directive in the input templates
                    b.SetNamespace("MyNamespace"); // define a namespace for the Template class
                    b.Build();
                });
                // points to the local path
                var project = RazorProject.Create(".");
                var te = new RazorTemplateEngine(engine, project);
                // get a file. My file is defined like this:
                //
                // @inherits RazorTemplate.MyTemplate
                // Hello @Model.Name, welcome to Razor World!
                //
                var item = project.GetItem("hello.txt");
                // parse and generate C# code, outputs it on the console
                var cs = te.GenerateCode(item);
                Console.WriteLine(cs.GeneratedCode);
                // now, use roslyn, parse the C# code
                var tree = CSharpSyntaxTree.ParseText(cs.GeneratedCode);
                // define the dll
                const string dllName = "hello";
                var compilation = CSharpCompilation.Create(dllName, new[] { tree },
                    new[]
                    {
                        MetadataReference.CreateFromFile(typeof(object).Assembly.Location), // include corlib
                        MetadataReference.CreateFromFile(Assembly.GetExecutingAssembly().Location), // this file (that contains the MyTemplate base class)
                        // for some reason on .NET core, I need to add this... this is not needed with .NET framework
                        MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location), "System.Runtime.dll")),
                    },
                    new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)); // we want a dll
                // compile the dll
                string path = Path.Combine(Path.GetFullPath("."), dllName + ".dll");
                var result = compilation.Emit(path);
                if (!result.Success)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, result.Diagnostics));
                    return;
                }
                // load the built DLL
                Console.WriteLine(path);
                var asm = Assembly.LoadFile(path);
                // the generated type is defined in our custom namespace, as we asked. "Template" is the type name that razor uses by default.
                var template = (MyTemplate)Activator.CreateInstance(asm.GetType("MyNamespace.Template"));
                // run the code.
                // should display "Hello Killroy, welcome to Razor World!"
                template.ExecuteAsync().Wait();
            }
        }
        // the model class. this is 100% specific to your context
        public class MyModel
        {
            // this will map to @Model.Name
            public string Name => "Killroy";
        }
        // the sample base template class. It's not mandatory but I think it's much easier.
        public abstract class MyTemplate
        {
            // this will map to @Model (property name)
            public MyModel Model => new MyModel();
            public void WriteLiteral(string literal)
            {
                // replace that by a text writer for example
                Console.Write(literal);
            }
            public void Write(object obj)
            {
                // replace that by a text writer for example
                Console.Write(obj);
            }
            public async virtual Task ExecuteAsync()
            {
                await Task.Yield(); // whatever, we just need something that compiles...
            }
        }
    }
