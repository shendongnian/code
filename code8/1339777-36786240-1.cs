        [MarkupExtensionReturnType(typeof(Class2))]
        public class Class2MarkupExtension : MarkupExtension
        {
            #region Properties
    
            [ConstructorArgument("class2Name")]
            public String Class2Name { get; set; }
    
            #endregion
    
            #region Constructors
    
            public Class2MarkupExtension()
            {
    
            }
    
            public Class2MarkupExtension(String class2Name)
            {
                Class2Name = class2Name;
            }
    
            #endregion
    
            #region Methods
    
            public override object ProvideValue(IServiceProvider provider)
            {
                Type providerType = provider.GetType();
    
                ///Get _xamlContext member from provider.
                FieldInfo fieldsInfo = providerType.GetField("_xamlContext", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);            
                object parserContex = fieldsInfo.GetValue(provider);
    
                ///Get _rootInstance member from _xamlContext member.
                providerType = parserContex.GetType();
                fieldsInfo = providerType.GetField("_rootInstance", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance);
    
                Class2 class2 = null;
                MainClass rootElement = (MainClass)fieldsInfo.GetValue(parserContex);
                if (rootElement.Class2ListProperty  != null && rootElement.Class2ListProperty.Count > 0)
                {
                    class2 = rootElement.Class2ListProperty .Where(s => s.Name.Equals(Class2Name)).FirstOrDefault();
                }
    
                if (scenario == null)
                {
                    class2 = new Class2() { Name = Class2Name };
                }
                return class2;
            }
            #endregion
        }
