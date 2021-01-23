    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
    
        public void Initialize(string title)
        {
            this.Text = title;
        }
    }
    
    public partial class EntityForm : BaseForm
    {
        public EntityForm()
        {
            InitializeComponent();
        }
    
        public void Initialize(Entity entity)
        {
            base.Initialize(entity.Name); // the 'base' keyword is somewhat redundant
        }
    }
