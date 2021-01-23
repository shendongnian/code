    namespace WebsitePingTest
    {
        using System;
        using System.Data;
        using System.Drawing;
        using System.Net.NetworkInformation;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                this.InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("Websitename", typeof(string)));
                dt.Columns.Add(new DataColumn("URL", typeof(string)));
                dt.Columns.Add(new DataColumn("Status", typeof(string)));
    
                var row = dt.NewRow();
                row["Websitename"] = "Google";
                row["URL"] = "www.google.com";
                dt.Rows.Add(row);
    
                row = dt.NewRow();
                row["Websitename"] = "Yahoo";
                row["URL"] = "www.yahoo.com";
                dt.Rows.Add(row);
    
                row = dt.NewRow();
                row["Websitename"] = "xasfjhasfkjh";
                row["URL"] = "www.xasfjhasfkjh.com";
                dt.Rows.Add(row);
                
                var view = new DataView(dt);
                this.dataGridView1.DataSource = view;
    
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {
                    var url = dataGridViewRow.Cells[1].Value.ToString();
    
                    var ping = new Ping();
    
                    PingReply result = null;
                    IPStatus status;
                    try
                    {
                        result = ping.Send(url);
                        status = result.Status;
                    }
                    catch (Exception ex)
                    {
                        status = IPStatus.DestinationHostUnreachable;
                    }
    
                    if (status != IPStatus.DestinationHostUnreachable)
                    {
                        dataGridViewRow.Cells[2].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dataGridViewRow.Cells[2].Style.BackColor = Color.Red;
                    }
                }
            }
        }
    }
