    internal class FileCodeParameter : IConstructorArgument
    {
        private readonly FileCode fileCode;
        public FileCodeParameter(FileCode fileCode)
        {
            this.fileCode = fileCode;
        }
        public string Name { get { return "File Code Parameter"; } }
        public bool ShouldInherit { get { return true; } }
        public FileCode FileCode  { get { return this.fileCode; } }
        public bool Equals(IParameter other)
        {
            var otherFileCodeParameter = other as FileCodeParameter;
            if (otherFileCodeParameter == null)
            {
                return false;
            }
            return otherFileCodeParameter.fileCode == this.fileCode;
        }
        public object GetValue(IContext context, ITarget target)
        {
            return this.fileCode;
        }
        public bool AppliesToTarget(IContext context, ITarget target)
        {
            return target.Type == typeof(FileCode);
        }
    }
