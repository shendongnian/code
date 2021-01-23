    public class Bootstrapper : UnityBootstrapper
    {
        protected override void OnInitialized()
        {
            NavigationService.Navigate("MainPage");
        }
        protected override void RegisterTypes()
        {
            RegisterAllPages();
        }
        private void RegisterAllPages()
        {
            var pageBaseTypeInfo = typeof(Page).GetTypeInfo();
            var types = GetType().GetTypeInfo().Assembly.DefinedTypes;
            var pageTypeInfos = types
                            .Where(x => x.IsClass && pageBaseTypeInfo.IsAssignableFrom(x));
            foreach (var page in pageTypeInfos)
            {
                // the next two lines do what RegisterTypeForNavigation does
                Container.RegisterType(typeof(object), page.AsType(), page.Name);
                PageNavigationRegistry.Register(page.Name, page.AsType());
            }
        }
    } 
