    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace CSharpForm {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e) {
                dataGridView1.Scroll += dataGridView1_Scroll;
            }
    
            void dataGridView1_Scroll(object sender, ScrollEventArgs e) {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll) {
                    try {
                        //  Set the position of HorizontalScrollBar
                        this.dataGridView2.HorizontalScrollingOffset = this.dataGridView1.HorizontalScrollingOffset;
                    }
                    catch { }
                }
                else if (e.ScrollOrientation == ScrollOrientation.VerticalScroll) {
                    try {
                        // Set the position of VerticalScrollBar
                        this.dataGridView2.FirstDisplayedScrollingRowIndex = this.dataGridView1.FirstDisplayedScrollingRowIndex;
                    }
                    catch {
                    }
                }
            }
        }
    }
