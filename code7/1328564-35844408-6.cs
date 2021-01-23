    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            //... Code removed for brevity           
            // Add APPLICATIONNAME name to path Utility
            ServerPathUtility.VariableResolutionStrategies["APPLICATIONNAME"] = p => {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                if (assembly != null)
                    return assembly.GetName().Name;
                return string.Empty;
            };           
        }
    }
