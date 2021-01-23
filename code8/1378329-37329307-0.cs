    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();    
    
                noteFlow1.NoteClick += new NoteFlow.ClickHandler(noteFlow1_NoteClick);
    
                noteFlow1.Add("Hello" + Environment.NewLine + "Hello2" + Environment.NewLine + Environment.NewLine);
                noteFlow1.Add("Hello" + Environment.NewLine + "Hello2" + Environment.NewLine + Environment.NewLine);
                noteFlow1.Add("Hello" + Environment.NewLine + "Hello2" + Environment.NewLine + Environment.NewLine);
                noteFlow1.Add("Hello" + Environment.NewLine + "Hello2" + Environment.NewLine + Environment.NewLine);
                noteFlow1.Add("Hello" + Environment.NewLine + "Hello2" + Environment.NewLine + Environment.NewLine);
            }
    
            void noteFlow1_NoteClick(object sender, EventArgs e)
            {
                TextBox sndr = sender as TextBox;
                sndr.SelectAll();
            }
        }
    
    
        public class NoteFlow : FlowLayoutPanel
        {
            public delegate void ClickHandler(object sender, EventArgs e);
            public event ClickHandler NoteClick;
    
            public NoteFlow()
            {
                base.AutoScroll = true;
                base.FlowDirection = FlowDirection.TopDown;
            }
    
            public void Add(string noteText)
            {
                TextBox TextBox1 = new TextBox();
                TextBox1.Multiline = true;
                TextBox1.Text = noteText;
                TextBox1.ReadOnly = true;
                TextBox1.BorderStyle = 0;
                TextBox1.BackColor = this.BackColor;
                TextBox1.TabStop = false;
                Size size = TextRenderer.MeasureText(TextBox1.Text, TextBox1.Font);
                TextBox1.Width = size.Width;
                TextBox1.Height = size.Height;
                TextBox1.Click += new EventHandler(TextBox1_Click);
                base.Controls.Add(TextBox1);
            }
    
            void TextBox1_Click(object sender, EventArgs e)
            {
                if (NoteClick != null)
                {
                    NoteClick(sender, e);
                }
            }
        }
    }
