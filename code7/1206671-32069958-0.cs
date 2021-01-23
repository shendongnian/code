    public class WinApi
    {
    	[DllImport("user32.dll")]
    	public static extern bool GetCaretPos(out System.Drawing.Point lpPoint);
    }
    
    TextBox t = new TextBox();
    void Main()
    {
    	Form f = new Form();
    	f.Controls.Add(t);
    	Button b = new Button();
    	b.Dock = DockStyle.Bottom;
    	b.Click += onClick;
    	f.Controls.Add(b);
    	f.ShowDialog();
    }
    
    // Define other methods and classes here
    void onClick(object sender, EventArgs e)
    {
    	Console.WriteLine("Start:" + t.SelectionStart + " len:" +t.SelectionLength);
    	Point p = new Point();
    	bool result = WinApi.GetCaretPos(out p);
    	Console.WriteLine(p);
    	int idx = t.GetCharIndexFromPosition(p);
    	Console.WriteLine(idx);
    }
