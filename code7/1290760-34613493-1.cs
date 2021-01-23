    var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            _kernel.Bind(
              x =>
                  x.FromAssembliesInPath(Path.GetDirectoryName(path))
                      .SelectAllClasses()
                      .InheritedFrom(typeof(IMapper<,>))
                      .BindAllInterfaces());
