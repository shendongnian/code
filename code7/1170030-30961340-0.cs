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
    
                lv.Dock = DockStyle.Fill;
                lv.View = View.Details;
                for (int i = 0; i < 2; i++) lv.Columns.Add("Title " + i, 500);
                for (int i = 0; i < 10; i++)
                {
                    var lvi = lv.Items.Add(slow);
                    lvi.SubItems.Add(slow);
                }
                Controls.Add(lv);
    
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
     
    }
