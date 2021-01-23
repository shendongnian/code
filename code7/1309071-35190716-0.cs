                    SyntaxTree tree = parser.Parse(line, "demo.cs");
                    var testClass = tree.Descendants.OfType<TypeDeclaration>().Single(x => x.Members == Method);
                    var testClassAttributes = testClass.Attributes.SelectMany(x => x.Attributes).ToArray();
                    List<Dictionary<string, object>> myList = new List<Dictionary<string, object>>();
                    string nombreControlador = null;
                    string rutaControlador = null;
                    string actionKeyPath = null;
                    string fullControllerPath = null;
                    int counter = 0;
                    
                    CSharpUnresolvedFile file = tree.ToTypeSystem();
                    
                    foreach (IUnresolvedTypeDefinition type in file.TopLevelTypeDefinitions)
                    {
                        nombreControlador = type.Name;
                        actionKeyPath = type.Fields.Skip(1).FirstOrDefault().ConstantValue.ToString();
                        fullControllerPath = type.Fields.First().ConstantValue.ToString();
                        rutaControlador = type.FullName;
                        foreach (IUnresolvedMethod method in type.Methods)
                        {
                            string documentation = file.GetDocumentation(method).Trim();
                            XDocument doc = XDocument.Parse("<documentation>" + documentation + "</documentation>");        
                            Dictionary<string, object> myDic = new Dictionary<string, object>();
                            Console.WriteLine(method.Name);
                            myDic.Add("MethodSignature", method.Name);
                            myDic.Add("MethodDescription", doc.Descendants().Select(e => (string)e.Element("summary")).FirstOrDefault());
                            myDic.Add("ActionKeyPath", actionKeyPath == null? "" : actionKeyPath);
                            myDic.Add("Counter", ++counter);
                            myDic.Add("FullControllerPath", fullControllerPath == null? "" : fullControllerPath);
                            myDic.Add("Route", method.Attributes == null ? "" : method.Attributes.Count <= 1 || method.Attributes.Skip(1) == null? "" : method.Attributes.SelectMany(a => a.);
                            myDic.Add("Verb", "");
                            myDic.Add("Input", "");
                            myDic.Add("Output", "");
                            myList.Add(myDic);
                        }
                    }
 
