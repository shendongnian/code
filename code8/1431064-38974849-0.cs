    public partial class Form1 : Form
    {
        int counter = 0;
        public Form1()
        {
            GlobalMouseHandler gmh = new GlobalMouseHandler();
            gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
            Application.AddMessageFilter(gmh);
            InitializeComponent();
        }
        void gmh_TheMouseMoved()
        {
            Point cur_pos = System.Windows.Forms.Cursor.Position;
            //System.Console.WriteLine(cur_pos);
            System.Console.WriteLine("{0}. [ {1},{2} ]", counter++, (cur_pos.X - this.Location.X), (cur_pos.Y - this.Location.Y));
        }
    }
    public delegate void MouseMovedEvent();
    public class GlobalMouseHandler : IMessageFilter
    {
        private const int WM_MOUSEMOVE = 0x0200;
        public event MouseMovedEvent TheMouseMoved;
        #region IMessageFilter Members
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)
            {
                if (TheMouseMoved != null)
                {
                    TheMouseMoved();
                }
            }
            // Always allow message to continue to the next filter control
            return false;
        }
        #endregion
    }
