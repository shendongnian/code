        public interface ICustomControl
        {
            void Accept(ControlVisitor visitor);
            void Clear();
            FieldType FieldType { get; set; }
            bool DocumentLoaded { get; set; }
        }
