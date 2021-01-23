    public static class MyRazorExtensions
    {
        public static MvcHtmlString RazorEncode(this HtmlHelper helper, string template)
        {
            return RazorEncode(helper, template, (object)null);
        }
        
        public static MvcHtmlString RazorEncode<TModel>(this HtmlHelper helper, string template, TModel model)
        {
            string output = Render(helper, template, model);
            return new MvcHtmlString(output);
        }
        
        private static string Render<TModel>(HtmlHelper helper, string template, TModel model)
        {
            // 1. Create a host for the razor engine
            //    TModel CANNOT be an anonymous class!
            var host = new RazorEngineHost(RazorCodeLanguage.GetLanguageByExtension("cshtml");
            host.DefaultNamespace = typeof(MyTemplateBase<TModel>).Namespace;
            host.DefaultBaseClass = nameof(MyTemplateBase<TModel>) + "<" + typeof(TModel).FullName + ">";
            host.NamespaceImports.Add("System.Web.Mvc.Html");
            
            // 2. Create an instance of the razor engine
            var engine = new RazorTemplateEngine(host);
            
            // 3. Parse the template into a CodeCompileUnit
            using (var reader = new StringReader(template))
            {
                razorResult = engine.GenerateCode(reader);
            }
            if (razorResult.ParserErrors.Count > 0)
            {
                throw new InvalidOperationException($"{razorResult.ParserErrors.Count} errors when parsing template string!");
            }
            
            // 4. Compile the produced code into an assembly
            var codeProvider = new CSharpCodeProvider();
            var compilerParameters = new CompilerParameters { GenerateInMemory = true };
            compilerParameters.ReferencedAssemblies.Add(typeof(MyTemplateBase<TModel>).Assembly.Location);
            compilerParameters.ReferencedAssemblies.Add(typeof(TModel).Assembly.Location);
            compilerParameters.ReferencedAssemblies.Add(typeof(HtmlHelper).Assembly.Location);
            var compilerResult = codeProvider.CompileAssemblyFromDom(compilerParameters, razorResult.GeneratedCode);
            if (compilerResult.Errors.HasErrors)
            {
                throw new InvalidOperationException($"{compilerResult.Errors.Count} errors when compiling template string!");
            }
            
            // 5. Create an instance of the compiled class and run it
            var templateType = compilerResult.CompiledAssembly.GetType($"{host.DefaultNamespace}.{host.DefaultClassName}");
            var templateImplementation = Activator.CreateInstance(templateType) as MyTemplateBase<TModel>;
            templateImplementation.Model = model;
            templateImplementation.Html = helper;
            templateImplementation.Execute();
            
            // 6. Return the html output
            return templateImplementation.Output.ToString();
        }
    }
