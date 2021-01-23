    // Your inventory_Viewer.viewer
	public partial class InventoryViewerForm
	{
		public InventoryViewerForm()
		{
		}
	}
    // The form from which to show the viewer. 
	public partial class MainForm
	{
        private readonly InventoryViewerForm _inventoryViewerForm;
		public MainForm()
		{
			_inventoryViewerForm = new InventoryViewerForm();
		}
		
		private void ShowInventoryViewerButton_Click(object sender, EventArgs e)
		{
			_inventoryViewerForm.Show();
		}
		
		private void ChangeImageButton_Click(object sender, EventArgs e)
		{
			// Dispose the previously loaded image.
			if (_inventoryViewerForm.Image != null)
			{
				_inventoryViewerForm.Image.Dispose();
			}
			
			_inventoryViewerForm.Image = Image.FromFile("NewImage.png");
		}
	}
