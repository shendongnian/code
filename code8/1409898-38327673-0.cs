    public partial class Form1 : Form
    {
    	private const int CircleDiameter = 20;
    	private const int PenWidth = 2;
    
    	private readonly List<Point> _points = new List<Point>();
    
    	public Form1()
    	{
    		InitializeComponent();
    	}
    
    	private void pictureBox1_DoubleClick(object sender, EventArgs e)
    	{
    		var cursorLocation = pictureBox1.PointToClient(Cursor.Position);
    
    		_points.Add(cursorLocation);
    
    		cursorLocation.X -= CircleDiameter/2;
    		cursorLocation.Y -= CircleDiameter/2;
    
    		using (var graphics = pictureBox1.CreateGraphics())
    		using (var pen = new Pen(Color.Tomato, PenWidth))
    		using (var brush = new SolidBrush(Color.White))
    		{
    			graphics.SmoothingMode = SmoothingMode.AntiAlias;
    			graphics.DrawEllipse(pen, cursorLocation.X, cursorLocation.Y, CircleDiameter, CircleDiameter);
    			graphics.FillEllipse(brush, cursorLocation.X, cursorLocation.Y, CircleDiameter, CircleDiameter);
    		}
    	}
    }
