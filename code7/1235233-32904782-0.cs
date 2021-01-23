    [MarkupExtensionReturnType(typeof(object))]
    public class LBBinding : MarkupExtension
    {
        private Binding _binding = new Binding();
        public Binding Binding
        {
            get { return _binding; }
            set { _binding = value; }
        }
        public PropertyPath Path
        {
            get { return _binding.Path; }
            set { _binding.Path = value; }
        }
    
    <TextBox Text="{customBinding:LBBinding Path=DummyString}"></TextBox>
