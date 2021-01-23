        public class ControlVisitor
        {
            private readonly DocumentContainer container;
            private readonly ErrorProvider provider;
            public ControlVisitor(DocumentContainer container, ErrorProvider provider)
            {
                this.container = container;
                this.provider = provider;
            }
            public void Visit(ICustomControlWithText control)
            {
                control.DocumentLoaded = true;
                control.Initialize(container, provider);
            }
            public void Visit(CustomCheckbox control)
            {
                control.DocumentLoaded = true;
                control.Initialize(container);
            }            
        }
