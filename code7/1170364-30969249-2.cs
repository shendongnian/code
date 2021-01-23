    public partial class StackOverflowForm : Form
    {
            public ViewModel Model { get; set; }
            public Dictionary<string, Control> BindableControls { get; set; }
            public StackOverflowForm()
            {
                Model = new ViewModel();
                Model.PropertyChanged += Model_PropertyChanged;
                BindableControls = new Dictionary<string, Control>();
                Model.Visible = false;
                InitializeComponent();
                RegisterBinding(boundButton, "Visible", Model, "Visible");
            }
    
            void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                foreach (var item in BindableControls)
                {
                    NotifyChange(item.Value, e.PropertyName);
                }
            }
    
            private void NotifyChange(Control control, string propertyName)
            {
                button1.DataBindings[propertyName].ReadValue();
            }
    
            private void RegisterBinding(Control control, string controlPropertyName, ViewModel _model, string modelPropertyName)
            {
                control.DataBindings.Add(controlPropertyName, _model, modelPropertyName, true, DataSourceUpdateMode.OnPropertyChanged);
                BindableControls[control.Name] = control;
            }
            private void SetPropertyButton_Click(object sender, EventArgs e)
            {
                Model.Visible = true;
            }
        }
    
        public class ViewModel : INotifyPropertyChanged
        {
            private bool _IsVisible;
            public bool Visible
            {
                get
                {
                    return _IsVisible;
                }
                set
                {
                    _IsVisible = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
