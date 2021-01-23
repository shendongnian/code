    public partial class UserControl1 : UserControl, IDataGridView
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DataGridView DataGridView
        {
            get { return dataGridView1; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ExtendedDataGridViewColumnCollectionEditor), typeof(UITypeEditor))]
        [MergableProperty(false)]
        public DataGridViewColumnCollection MyDataGridColumns
        {
            get { return dataGridView1.Columns; }
        }
    }
    public interface IDataGridView
    {
        DataGridView DataGridView { get; }
    }
    class ExtendedDataGridViewColumnCollectionEditor : UITypeEditor
    {
        private Form dataGridViewColumnCollectionDialog;
        private ExtendedDataGridViewColumnCollectionEditor() { }
        private static Form CreateColumnCollectionDialog(IServiceProvider provider)
        {
            var assembly = Assembly.Load(typeof(ControlDesigner).Assembly.ToString());
            var type = assembly.GetType("System.Windows.Forms.Design.DataGridViewColumnCollectionDialog");
            var ctr = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];
            return (Form)ctr.Invoke(new object[] { provider });
        }
        public static void SetLiveDataGridView(Form form, DataGridView grid)
        {
            var mi = form.GetType().GetMethod("SetLiveDataGridView", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(form, new object[] { grid });
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null && context != null)
            {
                var service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (service == null || context.Instance == null)
                    return value;
                var host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
                if (host == null)
                    return value;
                if (dataGridViewColumnCollectionDialog == null)
                    dataGridViewColumnCollectionDialog = CreateColumnCollectionDialog(provider);
                //Unfortunately we had to make property which returns inner datagridview  
                //to access it here because we need to pass DataGridView into SetLiveDataGridView () method 
                var grid = ((IDataGridView)context.Instance).DataGridView;
                //we have to set Site property because it will be accessed inside SetLiveDataGridView () method 
                //and by default it's usually null, so if we do not set it here, we will get exception inside SetLiveDataGridView () 
                var oldSite = grid.Site;
                grid.Site = ((UserControl)context.Instance).Site;
                //execute SetLiveDataGridView () via reflection 
                SetLiveDataGridView(dataGridViewColumnCollectionDialog, grid);
                using (var transaction = host.CreateTransaction("DataGridViewColumnCollectionTransaction"))
                {
                    if (service.ShowDialog(dataGridViewColumnCollectionDialog) == DialogResult.OK)
                        transaction.Commit();
                    else
                        transaction.Cancel();
                }
                //we need to set Site property back to the previous value to prevent problems with serializing our control 
                grid.Site = oldSite;
            }
            return value;
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
