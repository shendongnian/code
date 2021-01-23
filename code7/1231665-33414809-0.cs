    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;        // <--- add namespace AND reference!!
    using System.Drawing;             // <--- add namespace AND reference!!
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataGridView DGV = new DataGridView();
                List<string> test = new List<string>() 
                { "Anna", "Bertha", "Carol", "Doreen", "Erica", "Fran", "Gisa" };
                DGV.Columns.Add("No", "Number");
                DGV.Columns.Add("Name", "Name");
                DGV.Columns.Add("Age", "Age");
                DGV.Columns["Name"].DefaultCellStyle.Font = 
                                                 new Font(DGV.Font, FontStyle.Bold);
                for (int i = 0; i < test.Count; i++) DGV.Rows.Add(new[]
                    { (i + 1)+ "", test[i], i + 21 +""}); // cheap string array
                DGV.ScrollBars = ScrollBars.None;
                DGV.AllowUserToAddRows = false;
                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGV.RowHeadersVisible = false;
                var width = DGV.Columns.GetColumnsWidth(DataGridViewElementStates.None);
                DGV.ClientSize = new Size(width,  
                             DGV.ColumnHeadersHeight + DGV.RowCount * (DGV.Rows[0].Height) );
                Bitmap bmp = new Bitmap(DGV.ClientSize.Width, DGV.ClientSize.Height);
                DGV.DrawToBitmap(bmp, DGV.ClientRectangle);
                bmp.Save("D:\\testDGV.png", System.Drawing.Imaging.ImageFormat.Png);
                bmp.Dispose();
            }
        }
    }
