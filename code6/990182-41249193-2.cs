    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace WindowsFormsApplication1
    {
        class TextBoxIcon
        {
            public static TextBoxIcon AddIcon(TextBox textbox, Image icon)
            {
                if (icon != null) {
                    return new TextBoxIcon(textbox, icon);
                } else {
                    return null;
                }
            }
    
            private TextBox _TextBox;
            private PictureBox _PictureBox;
    
            private TextBoxIcon(TextBox textbox, Image icon) {
                this._TextBox = textbox;
                this._PictureBox = new PictureBox();
                this._PictureBox.BackColor = textbox.BackColor;
                this._PictureBox.Image = ScaleImage(icon);
                this._TextBox.Parent.Controls.Add(_PictureBox);
                this._PictureBox.Location = new Point(textbox.Left + 5, textbox.Top + 2);
                this._PictureBox.Size = new Size(textbox.Width - 10, textbox.Height - 4);
                this._PictureBox.Anchor = textbox.Anchor;
                this._PictureBox.Visible = _TextBox.Visible;
                this._PictureBox.BringToFront();
                textbox.Resize += TextBox_Resize;
                textbox.TextChanged += TextBox_TextChanged;
                textbox.Leave += TextBox_Leave;
                _PictureBox.Click +=  PictureBox_Click;
                textbox.VisibleChanged += TextBox_VisibleChanged;
            }
    
            public static Image ScaleImage(Image img) {
                if (img.Height == 16) {
                    return img;
                } else {
                    return new Bitmap(img, new Size((int)((img.Height / 16.0) * img.Width), 16));
                }
            }
    
            private void TextBox_Resize(Object sender, EventArgs e) {
                _PictureBox.Size = new Size(_TextBox.Width - 10, _TextBox.Height - 4);
            }
    
            private void TextBox_VisibleChanged(Object sender, EventArgs e) {
                _PictureBox.Visible = _TextBox.Visible;
            }
    
            private void ShowPictureBox() {
                _PictureBox.Visible = String.IsNullOrEmpty(_TextBox.Text);
            }
    
            private void TextBox_TextChanged(Object sender, EventArgs e) {
                ShowPictureBox();
            }
    
            private void TextBox_Leave(Object sender, EventArgs e) {
                ShowPictureBox();
            }
    
            public void PictureBox_Click(object sender, EventArgs e) { 
                _TextBox.Focus();
            }
        }
    }
