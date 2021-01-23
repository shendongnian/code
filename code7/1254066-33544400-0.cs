     protected override System.Reflection.Assembly[] GetViewAssemblies()
        {
            var result = base.GetViewAssemblies();
            var assemblyList = result.ToList();
            var assemblyType = typeof(LogonView);
            assemblyList.Add( assemblyType.GetTypeInfo().Assembly);
            return assemblyList.ToArray();
        }
        protected override System.Reflection.Assembly[] GetViewModelAssemblies()
        {
          //  return base.GetViewModelAssemblies();
            var result = base.GetViewModelAssemblies();
            var assemblyList = result.ToList();
            var assemblyType = typeof(SBG.NBOL.StartupModule.ViewModels.LogonViewModel);
            assemblyList.Add(assemblyType.GetTypeInfo().Assembly);
            return assemblyList.ToArray();
        }
