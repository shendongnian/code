        public class InitializerForControlWithTextBase : IInitializer
        {
            public void Intialize(Control control, DocumentContainer container, ErrorProvider provider)
            {
                var c = control as ICustomControlWithText;
                c.DocumentLoaded = true;
                c.Initialize(container, provider);
            }
            public bool Accept(Control c)
            {
                return GetBaseType().IsInstanceOfType(c);
            }
            public Type GetBaseType()
            {
                return typeof(ICustomControlWithText);
            }
        }
        public class InitializerForCustomCheckbox : IInitializer
        {
            public void Intialize(Control control, DocumentContainer container, ErrorProvider provider)
            {
                var c = control as CustomCheckbox;
                c.DocumentLoaded = true;
                c.Initialize(container);
            }
            public bool Accept(Control c)
            {
                return GetBaseType().IsInstanceOfType(c);
            }
            public Type GetBaseType()
            {
                return typeof(CustomCheckbox);
            }
        }
