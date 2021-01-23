    using System;
    using System.Reflection;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.SetStyle(ControlStyles.Selectable, true);
            this.pictureBox1.SetStyle(ControlStyles.UserMouse, true);
            this.pictureBox1.PreviewKeyDown +=
                new PreviewKeyDownEventHandler(pictureBox1_PreviewKeyDown);
        }
        void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Left)
                MessageBox.Show("Left");
        }
    }
    public static class Extensions
    {
        public static void SetStyle(this Control control, ControlStyles flags, bool value)
        {
            Type type = control.GetType();
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            MethodInfo method = type.GetMethod("SetStyle", bindingFlags);
            if (method != null)
            {
                object[] param = { flags, value };
                method.Invoke(control, param);
            }
        }
    }
