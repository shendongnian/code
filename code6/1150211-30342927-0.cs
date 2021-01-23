    	public partial class SampleForm : Form
        {
            public SampleForm()
            {
                InitializeComponent(); // ColImage is declared as a DataGridViewImageColumn in the code behind.
                ColImage.ImageLayout = DataGridViewImageCellLayout.Stretch; // You could set image layout if you wish.
            }
    
            
        	private void pictureBox1_DoubleClick(object sender, EventArgs e)
        	{
            	var img = pictureBox1.Image;
            	dataGridView1.Rows.Add(img);
        	}
        }
