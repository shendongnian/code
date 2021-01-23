    public partial class MainForm : Form
    {
        private BusinessLogic.PDVCollection _pdvColllection;
        private BusinessLogic.PDV _pdvCurrentlySelected;
    
        public MainForm()
        {
            InitializeComponent();
    
            // Keep a reference to the editable root collection
            _pdvColllection = BusinessLogic.PDVCollection.GetList();
    
            // Initialise the BindingSource with data. The DataGridView is connected to the BindingSource
            pdvCollectionBindingSource.DataSource = _pdvColllection;
        }
    
        private void pdvCollectionBindingSource_CurrentChanged( object sender, EventArgs e )
        {
            // Update a local reference with the currently selected item in the binding source (set by the DataGridView)
            _pdvCurrentlySelected = pdvCollectionBindingSource.Current as BusinessLogic.PDV;
        }
    
        private void saveButton_Click( object sender, EventArgs e )
        {
            // Save the root collection - this will update all of the items in the collection.
            // - Note a new root collection is returned.
            if ( !_pdvColllection.IsValid )
            {
                MessageBox.Show( "Cannot save list because some items are invalid", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }
    
            _pdvColllection = _pdvColllection.Save();
    
            // Update the binding source with the new instance;
            pdvCollectionBindingSource.DataSource = null;
            pdvCollectionBindingSource.DataSource = _pdvColllection;
        }
    
        private void deleteButton_Click( object sender, EventArgs e )
        {
            // Delete requires a PDV instance to be selected in the DataGridView
            if ( _pdvCurrentlySelected == null )
            {
                MessageBox.Show( "Item to delete not selected", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }
    
            _pdvColllection.Remove( _pdvCurrentlySelected );
    
            // Depending on whether you want to save this delete to the background immediately, or leave it up to the user you may want to 
            // Save the root collection next:
            saveButton.PerformClick();
        }
    }
