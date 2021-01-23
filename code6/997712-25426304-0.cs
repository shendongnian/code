    public partial class Form1 : Form 
    { 
        public Form1() 
        { 
          InitializeComponent(); 
          menuStrip1.Renderer = new MyRenderer(); 
        } 
    
        private class MyRenderer : ToolStripProfessionalRenderer 
        { 
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)      
            { 
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size); 
                Color c = e.Item.Selected ? Color.Azure : Color.Beige; 
                using (SolidBrush brush = new SolidBrush(c)) 
                    e.Graphics.FillRectangle(brush, rc); 
            } 
        } 
    } 
