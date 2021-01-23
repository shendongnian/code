    public class MenuBar : Component
    {
        BindingList<StandardItems> _standardItems = new BindingList<StandardItems>()
    
        [Category("Einstellungen")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]    
        public BindingList<StandardItems> StandardItems
        {
            get { return _standardItems; }
            set
            {
                _standardItems = value;
                _standardItems.ListChanged -= _standardItems_ListChanged;
                _standardItems.ListChanged += _standardItems_ListChanged;
            }
        }
    }
