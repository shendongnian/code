        public interface IInitializer
        {
            void Intialize(Control c, DocumentContainer container, ErrorProvider provider);
            bool Accept(Control c);
        }
