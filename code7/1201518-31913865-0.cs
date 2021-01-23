    public class LabelDTO
    {
        public LabeLDTO(Label label)
        {
            Name = label.Name;
            Text = label.Text;
        }
    
        protected LabelDTO()
        {
        }
    
        public string Text { get; set; }
        public string Name { get; set; }
    }
    public class DtoFactory
    {
        Dictionary<Type, Func<Control, object> _factories = new Dictionary<Type, Func<Control, object>();
       
        public DtoFactory()
        {
            _factories.Add(typeof(Label), ctrl => new LabelDTO(ctrl));
        }
        public object Create(Control control)
        {
            Func<Control, object> factoryMethod;
            return _factories.TryGetValue(control.GetType(), out factoryMethod)
                ? factoryMethod(control)
                : throw new NotSupportedException("Failed to find factory for " + control.GetType().FullName); 
        }
    }
    List<object> formData = new List<object>();
    foreach (var control in Form.Controls) 
    {
        var dto = DtoFactory.Create(control);
        formData.Add(dto);        
    }
    var json = JsonConvert.SerializeObject(formData);
