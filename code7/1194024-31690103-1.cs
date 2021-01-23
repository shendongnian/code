    using System.Windows.Forms;
    using System.Drawing;
    void Main()
    {
    	var pictures = Directory.GetFiles(@"D:\MyPictures", "*.jpg");
    	var rnd = new Random();
    	var form = new Form();
    	var control = new MyImageControl() { Dock = DockStyle.Fill };
    	form.Controls.Add(control);
    	var timer = new System.Windows.Forms.Timer();
    	timer.Interval = 50;
    	timer.Tick += (sender, args) => 
    	{
    		if (control.BitMap != null)
    			control.BitMap.Dispose();
    		control.BitMap = new Bitmap(pictures[rnd.Next(0, pictures.Length)]);
    		control.Invalidate();
    	};
    	timer.Enabled = true;
    	form.ShowDialog();
    }
    
    public class MyImageControl : UserControl // or PictureBox
    {
    	public Bitmap BitMap { get; set; }
    	public MyImageControl()
    	{
    		this.Paint += Graph_Paint;
    		this.Resize += Graph_Resize;
    	}
    	private void Graph_Paint(object sender, PaintEventArgs e)
    	{
    		if (this.BitMap != null)
    		{
    			lock (this.BitMap)
    			{
    				Graphics g = e.Graphics;
    				g.DrawImage(this.BitMap, this.ClientRectangle);
    			}
    		}
    	}
    	private void Graph_Resize(object sender, System.EventArgs e)
    	{
    		this.Invalidate();
    	} 
    }
