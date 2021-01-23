    public partial class Form1 : Form
    {
    	static ConcurrentQueue<Image>  buffer = new ConcurrentQueue<Image>();
    	static Random r = new Random();
    
    	public Form1()
    	{
    		InitializeComponent();
    		backgroundWorker1.RunWorkerAsync();
    		// this is already a great performance win ...
    		DoubleBuffered = true;
    	}
    
    	private void Form1_Paint(object sender, PaintEventArgs e)
    	{
    		Image img =null;
    		// get from buffer ..
    		if (!buffer.TryDequeue(out img))
    		{
    			// nothing available
    			// direct random
    			for (var x = 0; x < e.ClipRectangle.Width; x++)
    			{
    				for (var y = 0; y < e.ClipRectangle.Height; y++)
    				{
    					using (var pen = new Pen(new SolidBrush(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255)))))
    					{
    						e.Graphics.DrawRectangle(pen, x, y, 1, 1);
    					}
    				}
    			}
    		}
    		else
    		{
    			// otherwise Draw the prepared image
    			e.Graphics.DrawImage(img,0,0);
    			Trace.WriteLine(buffer.Count);
    			img.Dispose();
    		}
    	}
    
    	private void button1_Click(object sender, EventArgs e)
    	{
    		// force a repaint of the Form
    		Invalidate();
    	}
    
    	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    	{
    		// as long as the form is not disposed
    		while (!IsDisposed)
    		{
    			// we keep 60 images in memory
    			if (buffer.Count < 60)
    			{
    				// bitmap
    				var bmp = new Bitmap(this.Width, this.Height);
    				var img = Graphics.FromImage(bmp);
    				// draw
    				for (int i = 0; i < 3600; i++)
    				{
    					using (var pen = new Pen(new SolidBrush(Color.FromArgb(r.Next(255), r.Next(255), r.Next(255)))))
    					{
    						img.DrawRectangle(pen, r.Next(Width),r.Next(Height), r.Next(Width), r.Next(Height));
    					}
    				}
    				// store the drawing in the buffer
    				buffer.Enqueue(bmp);
    			}
    			else
    			{
    				// simple and naive way to give other threads a bit of room
    				Thread.Sleep(0);
    			}
    		}
    	}
    }
 
