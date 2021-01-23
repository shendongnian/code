    public interface IExportColumn<TModel> where TModel : class
    {
        string Header { get; }
        Func<TModel, Object> Display { get; }
    }
    public class ExportColumn<TModel, TProperty> : IExportColumn<TModel> where TModel : class
    {
        private readonly string _header;
        private readonly Expression<Func<TModel, TProperty>> _display;
        public string Header { get { return _header; } }
        public Func<TModel, Object> Display { get { return model => _display.Compile().Invoke(model); } }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ExportColumn(string header, Expression<Func<TModel, TProperty>> display)
        {
            _header = header;
            _display = display; ;
        }
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Header: {0}, Display: {1}", _header, _display);
        }
    }
