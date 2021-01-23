    using LOGINPAGE.Models; //It's a folder
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace LOGINPAGE
    {
        public partial class FACULTY : Form
        {
            public FACULTY()
            {
                InitializeComponent();
    
                SetFloorsToDropDown();
            }
    
            private void FACULTY_Load(object sender, EventArgs e)
            {
                // TODO: This line of code loads data into the 'roomInfoDataSet2.Table' table. You can move, or remove it, as needed.
                this.tableTableAdapter1.Fill(this.roomInfoDataSet2.Table);
                // TODO: This line of code loads data into the 'roomInfoDataSet1.Table' table. You can move, or remove it, as needed.
                this.tableTableAdapter.Fill(this.roomInfoDataSet1.Table);
    
    
            }
    
            private void xButton5_Click(object sender, EventArgs e)
            {
                Rooms.SelectedIndex = -1;
                Floor.SelectedIndex = -1;
            }
    
            private void xButton2_Click(object sender, EventArgs e)
            {
                this.Close();
                Application.Exit();
            }
    
            private void xButton3_Click(object sender, EventArgs e)
            {
                this.Hide();
                EMERGENCY EM = new EMERGENCY();
                EM.Show();
            }
    
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
    
            }
    
            private void Rooms_SelectedIndexChanged_1(object sender, EventArgs e)
            {
                Rooms.SelectedIndex = -1;
            }
    
            private void xButton1_Click(object sender, EventArgs e)
            {
    
            }
    
            private void Floor_SelectedIndexChanged(object sender, EventArgs e)
            {
                dataGridView1.Rows.Clear();
    
                if (Floor.SelectedItem.ToString() != "SELECT FLOOR")
                {
                    foreach (var item in roomInfoDataSet1.Table.Where(x => x.Room_Number.Substring(0, 1) == Convert.ToString(Floor.SelectedValue)))
                    {
                        string[] row = new string[] { item.Room_Number, item.Equipment_Type, item.Availability, Convert.ToString(Floor.SelectedValue) };
    
                        dataGridView1.Rows.Add(row);
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                    }
                }
            }
    
            private void SetFloorsToDropDown()
            {
                List<DropDownModel> floorList = new List<DropDownModel>();
    
                floorList.Add(new DropDownModel()
                {
                    Id = 0,
                    Name = "SELECT FLOOR",
                });
    
                floorList.Add(new DropDownModel()
                {
                    Id = 1,
                    Name = "1st Floor",
                });
    
                floorList.Add(new DropDownModel()
                {
                    Id = 2,
                    Name = "2nd Floor",
                });
    
                floorList.Add(new DropDownModel()
                {
                    Id = 3,
                    Name = "3rd Floor",
                });
    
                floorList.Add(new DropDownModel()
                {
                    Id = 4,
                    Name = "4th Floor",
                });
    
                floorList.Add(new DropDownModel()
                {
                    Id = 5,
                    Name = "5th Floor",
                });
    
                floorList.Add(new DropDownModel()
                {
                    Id = 6,
                    Name = "6th Floor",
                });
    
                Floor.DataSource = floorList;
                Floor.DisplayMember = "Name";
                Floor.ValueMember = "Id";
            }
    
        }
    }
