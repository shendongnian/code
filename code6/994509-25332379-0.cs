    public class DataTemplateManager
    {
        private readonly Dictionary<Type, Type> dataTemplates = new Dictionary<Type, Type>();
        public void Add<TModel, TView>() where TView : Control, new()
        {
            dataTemplates.Add(typeof (TModel), typeof (TView));
        }
        public void Add(Type modelType, Type viewType)
        {
            if (!typeof (Control).IsAssignableFrom(viewType))
                throw new InvalidOperationException("viewType must derive from System.Windows.Forms.Control");
            dataTemplates.Add(modelType, viewType);
        }
        public Control Resolve(object model)
        {
            if (model == null)
                return null;
            var type = model.GetType();
            if (!dataTemplates.ContainsKey(type))
                return null;
            var viewType = dataTemplates[type];
            var control = Activator.CreateInstance(viewType);
            return control as Control;
        }
    }
