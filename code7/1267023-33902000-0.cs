    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Utility {
        public class MyDataGridView : DataGridView {
    
            public string EmptyResultText { get; set; }
    
            public MyDataGridView() {
                this.Paint += MyDataGridView_Paint;
            }
    
            private void MyDataGridView_Paint(object sender, PaintEventArgs e) {
                if (!string.IsNullOrEmpty(EmptyResultText)) {
                    if (this.Rows.Count == 0) {
                        using (var gfx = e.Graphics) {
                            gfx.DrawString(this.EmptyResultText, this.Font, Brushes.Black, 
                                new PointF((this.Width - this.Font.Size * EmptyResultText.Length) / 2, this.Height / 2));
                        }
                    }
                }
            }
        }
    }
