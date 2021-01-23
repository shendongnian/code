    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace FCFS_2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
               
            }
           
            private void btnFCFS_Click(object sender, EventArgs e)
            {
                int  a1, a2, a3, a4, a5, b1, b2, b3, b4, b5;
                a1 = Convert.ToInt32(txtAT1.Text); a2 = Convert.ToInt32(txtAT2.Text); a3 = Convert.ToInt32(txtAT3.Text); a4 = Convert.ToInt32(txtAT4.Text);
                a5 = Convert.ToInt32(txtAT5.Text); b1 = Convert.ToInt32(txtBT1.Text); b2 = Convert.ToInt32(txtBT2.Text); b3 = Convert.ToInt32(txtBT3.Text);
                b4 = Convert.ToInt32(txtBT4.Text); b5 = Convert.ToInt32(txtBT5.Text);
                int[][] arrayprocess = new int[][] { new int[] { a1, b1 }, new int[] { a2, b2 }, new int[] { a3, b3 }, new int[] { a4, b4 }, new int[] { a5, b5 } };
                Sort<int>(arrayprocess, 0);
                label8.Text = Convert.ToString(arrayprocess[0][0] + " " + arrayprocess[1][0] + " " + arrayprocess[2][0] + " " + arrayprocess[3][0] + " " + arrayprocess[4][0]);
                label9.Text = Convert.ToString(arrayprocess[0][1] + " " + arrayprocess[1][1] + " " + arrayprocess[2][1] + " " + arrayprocess[3][1] + " " + arrayprocess[4][1]);
                int totalburst = arrayprocess[0][1] + arrayprocess[1][1] + arrayprocess[2][1] + arrayprocess[3][1] + arrayprocess[4][1];
                label10.Text = Convert.ToString(totalburst);
                //Gantt Chart
                Graphics dc = this.CreateGraphics();
                Pen Bluepen = new Pen(Color.Blue, 3);
                dc.DrawRectangle(Bluepen, 50, 200, arrayprocess[0][1] * 10, 20);
                Pen Redpen = new Pen(Color.Red, 3);
                dc.DrawRectangle(Redpen, 50 + arrayprocess[0][1] * 10, 200, arrayprocess[1][1] * 10, 20);
                Pen Yellowpen = new Pen(Color.Yellow, 3);
                dc.DrawRectangle(Yellowpen, 50 + arrayprocess[0][1] * 10 + arrayprocess[1][1] * 10, 200, arrayprocess[2][1] * 10, 20);
                Pen Greenpen = new Pen(Color.Green, 3);
                dc.DrawRectangle(Greenpen, 50 + (arrayprocess[0][1] + arrayprocess[1][1] + arrayprocess[2][1]) * 10, 200, arrayprocess[3][1] * 10, 20);
                Pen Violetpen = new Pen(Color.Violet, 3);
                dc.DrawRectangle(Violetpen, 50 + (arrayprocess[0][1] + arrayprocess[1][1] + arrayprocess[2][1] + arrayprocess[3][1]) * 10, 200, arrayprocess[4][1] * 10, 20);
                lblWT1.Text = Convert.ToString(arrayprocess[0][0]);
                lblWT2.Text = Convert.ToString(arrayprocess[0][1]-arrayprocess[1][0]);
                lblWT3.Text = Convert.ToString(arrayprocess[0][1]+arrayprocess[1][1]-arrayprocess[2][0]);
                lblWT4.Text = Convert.ToString(arrayprocess[0][1]+arrayprocess[1][1]+arrayprocess[2][1]-arrayprocess[3][0]);
                lblWT5.Text = Convert.ToString(arrayprocess[0][1]+arrayprocess[1][1]+arrayprocess[2][1]+ arrayprocess[3][1] - arrayprocess[4][0]);
                lblTAT1.Text = Convert.ToString(arrayprocess[0][0]+arrayprocess[0][1]);
                lblTAT2.Text = Convert.ToString(arrayprocess[0][1]-arrayprocess[1][0]+arrayprocess[1][1]);
                lblTAT3.Text = Convert.ToString(arrayprocess[0][1]+arrayprocess[1][1]-arrayprocess[2][0]+arrayprocess[2][1]);
                lblTAT4.Text = Convert.ToString(arrayprocess[0][1]+arrayprocess[1][1]+arrayprocess[2][1]-arrayprocess[3][0]+arrayprocess[3][1]);
                lblTAT5.Text = Convert.ToString(arrayprocess[0][1]+arrayprocess[1][1]+arrayprocess[2][1]+ arrayprocess[3][1] - arrayprocess[4][0]+arrayprocess[4][1]);
            }
            public void Sort<T>(T[][] data, int col)
            {
                Comparer<T> comparer = Comparer<T>.Default;
                Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
            }
        }
    }
