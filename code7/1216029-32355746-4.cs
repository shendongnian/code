    public class OptionalWrap : IDisposable
    {
        private readonly HtmlHelper _Helper;
        private readonly TagBuilder _Tag;
        private readonly bool _test;
        public OptionalWrap(HtmlHelper helper, TagBuilder tag, bool test)
        {
            _Helper = helper;
            _Tag = tag;
            _test = test;
        }
        public void Dispose()
        {
            if (_test)
            {
                _Helper.ViewContext.Writer.Write(_Tag.ToString(TagRenderMode.EndTag));
            }
        }
    }
	
