    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace SlowLVRendering
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);
        private uint LVM_SETTEXTBKCOLOR = 0x1026;
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
                this.Load += new System.EventHandler(this.Form1_Load);
    
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                const string slow = "ヽ(  ´。㉨°)ﾉ Ƹ̴Ӂ̴Ʒ~ ღ ( ヽ(  ´。㉨°)ﾉ  ༼ つ´º㉨º ༽つ ) (」ﾟヘﾟ)」ヽ(  ´。㉨°)ﾉ Ƹ̴Ӂ̴Ʒ~ ღ ( ヽ(  ´。㉨°)ﾉ  ༼ つ´º㉨º ༽つ ) (」ﾟヘﾟ)」";
                ListView lv = new BufferedListView();
                // new ListView();
                //new ListViewWithLessSuck();
    
                lv.Dock = DockStyle.Fill;
                lv.View = View.Details;
                for (int i = 0; i < 2; i++) lv.Columns.Add("Title " + i, 500);
                for (int i = 0; i < 10; i++)
                {
                    var lvi = lv.Items.Add(slow);
                    lvi.SubItems.Add(slow);
                }
                Controls.Add(lv);
            //SendMessage(lv.Handle, LVM_SETTEXTBKCOLOR, IntPtr.Zero, unchecked((IntPtr)(int)0xFFFFFF));
    
            }
    
        }
        public class BufferedListView : ListView
        {
            public BufferedListView()
                : base()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            }
        }
    class ListViewWithLessSuck : ListView
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public uint idFrom;
            public uint code;
        }
        private const uint NM_CUSTOMDRAW = unchecked((uint)-12);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x204E)
            {
                NMHDR hdr = (NMHDR)m.GetLParam(typeof(NMHDR));
                if (hdr.code == NM_CUSTOMDRAW)
                {
                    m.Result = (IntPtr)0;
                    return;
                }
            }
            base.WndProc(ref m);
        }
     
    }
