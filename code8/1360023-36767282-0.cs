    using MySql.Data.MySqlClient;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;
    
    namespace Vertical_label
    {
        public partial class Vertical_label: Form
        {
            public Vertical_label()
            {
                InitializeComponent();
            }
      private void label1_Paint(object sender, PaintEventArgs e)
            {
    
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
    
                using (Font the_font = new Font("Microsoft Sans Serif", 10 , FontStyle.Bold))
                {
                    int x = 5, y = 50;
                    DrawRotatedTextAt(e.Graphics, -90, "DATA", x, y, the_font, Brushes.Black);
    
                }
            }
     private void DrawRotatedTextAt(Graphics gr, float angle, string txt, int x, int y, Font the_font, Brush the_brush)
            {
                // Save the graphics state.
                GraphicsState state = gr.Save();
                gr.ResetTransform();
    
                // Rotate.
                gr.RotateTransform(angle);
    
                // Translate to desired position. Be sure to append
                // the rotation so it occurs after the rotation.
                gr.TranslateTransform(x, y, MatrixOrder.Append);
    
                // Draw the text at the origin.
                gr.DrawString(txt, the_font, the_brush, 0, 0);
    
                // Restore the graphics state.
                gr.Restore(state);
            }
         }
       }
     }
