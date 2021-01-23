    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Integration;
    using System.Windows.Media;
    public class MyWPFTextBox : System.Windows.Forms.UserControl
    {
        private ElementHost elementHost = new ElementHost();
        private TextBox textBox = new TextBox();
        public MyWPFTextBox()
        {
            textBox.SelectionBrush = new SolidColorBrush(Colors.Gray);
            textBox.SelectionOpacity = 0.5;
            textBox.TextAlignment = TextAlignment.Left;
            textBox.VerticalContentAlignment = VerticalAlignment.Center;
            elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            elementHost.Name = "elementHost";
            elementHost.Child = textBox;
            textBox.TextChanged += (s, e) => OnTextChanged(EventArgs.Empty);
            Controls.Add(elementHost);
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
    }
