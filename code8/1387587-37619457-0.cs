    public static PropertyInfo CreateProperty(string value)
    {
        string code=@"
        private string name = \"{0}\"
        public string Name {
            get{
                return this.name;
            }
            set{
                this.name=value;
            }
        }
        ";
        var code = string.Format(code, value);
        CSharpCodeProvider provider = new CSharpCodeProvider();
        CompilerResults results = provider.CompileAssemblyFromSource(new CompilerParameters(), code);
    }
