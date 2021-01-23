    public partial class Form1 : Form
    {
        GraphPane myPane;
        public Form1()
        {
            InitializeComponent();
            
            myPane = zedGraphControl1.GraphPane;
            AddTxtObject();
        }
        private void AddTxtObject()
        {
            TextObj txtObj = new TextObj("ZedGraph Version 5.1.5.xxx", 0.7, 0.8, CoordType.PaneFraction, AlignH.Left, AlignV.Bottom);
            txtObj.FontSpec.FontColor = Color.GreenYellow;
            txtObj.FontSpec.Size = 10;
            txtObj.FontSpec.Fill.Color = Color.Black;
            txtObj.FontSpec.Border.Color = Color.Black;
            txtObj.FontSpec.Border.Width = 25.0f;
                        
            myPane.GraphObjList.Add(txtObj);
            zedGraphControl1.Refresh();
        }
    }
