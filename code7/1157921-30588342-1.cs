    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinForm
    {
        public partial class frmMain : Form
        {
            /// <summary>
            /// form constructor
            /// </summary>
            public frmMain()
            {
                InitializeComponent();
            }
    
            private ListView listView;
            private TextBox textBox;
    
            /// <summary>
            /// form load
            /// </summary>
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                // create list view
                listView = new ListView()
                {
                    Location = new Point(8, 8),
                    Size = new Size(this.ClientSize.Width - 16, this.ClientSize.Height - 42),
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                    View = View.List,
                };
                listView.Columns.Add(new ColumnHeader() { Text = "Header" });
                listView.Sorting = SortOrder.Ascending;
                this.Controls.Add(listView);
    
                // create textbox
                textBox = new TextBox()
                {
                    Location = new Point(8, listView.Bottom + 8),
                    Size = new Size(this.ClientSize.Width - 16, 20),
                    Anchor = AnchorStyles.Left | AnchorStyles.Bottom,
                    Text = "Write some text here and press [Enter]"
                };
                this.Controls.Add(textBox);
    
                // bind textbox KeyDown event
                textBox.KeyDown += textBox_KeyDown;
            }
    
            /// <summary>
            /// KeyDown event handler
            /// </summary>
            void textBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // [Enter] key pressed
                    TextBox tb = (TextBox)sender;
                    string text = tb.Text;
    
                    if (listView.Items.ContainsKey(text))
                    {
                        // item already added
                        MessageBox.Show(string.Format("String '{0}' already added", text));
                    }
                    else
                    {
                        // add new item
                        listView.Items.Add(text, text, 0);
                        listView.Sort();
                        tb.Clear();
                    }
                }
            }
        }
    }
