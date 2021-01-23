    public abstract class MyTemplateBase<TModel>
    {
        public TModel Model { get; set; }
        public HtmlHelper Html { get; set; }
        public void WriteLiteral(object output)
        {
            Output.Append(output.ToString());
        }
        public void Write(object output)
        {
            Output.Append(Html.Encode(output.ToString()));
        }
        public abstract void Execute();
        public StringBuilder Output { get; private set; } = new StringBuilder();
    }
