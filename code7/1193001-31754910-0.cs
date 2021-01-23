    using System;
    using System.Windows.Forms;
    
    namespace ListBoxNotWorking
    {
        public partial class Form1 : Form
        {
            private System.Windows.Forms.ListBox lst_ProductName;
            private System.Windows.Forms.TextBox txt_product_name;
            public Form1()
            {
                this.lst_ProductName = new System.Windows.Forms.ListBox();
                this.txt_product_name = new System.Windows.Forms.TextBox();
    
                this.lst_ProductName.FormattingEnabled = true;
                this.lst_ProductName.Items.AddRange(new object[] {
                "item1",
                "item2",
                "item3"});
                this.lst_ProductName.Location = new System.Drawing.Point(81, 50);
                this.lst_ProductName.Name = "lst_ProductName";
                this.lst_ProductName.Size = new System.Drawing.Size(120, 95);
                this.lst_ProductName.TabIndex = 0;
                this.lst_ProductName.DoubleClick += new System.EventHandler(this.lst_ProductName_DoubleClick);
    
                this.txt_product_name.Location = new System.Drawing.Point(86, 189);
                this.txt_product_name.Name = "txt_product_name";
                this.txt_product_name.Size = new System.Drawing.Size(100, 20);
                this.txt_product_name.TabIndex = 1;
    
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.txt_product_name);
                this.Controls.Add(this.lst_ProductName);
            }
            private void lst_ProductName_DoubleClick(object sender, EventArgs e)
            {
                string str = lst_ProductName.SelectedItems[0].ToString();
                //  txt_ID_product.Text = ds6.Tables["T"].Rows[lst_ProductName.SelectedIndex]["Id"].ToString();
                txt_product_name.Text = str;
                lst_ProductName.Visible = false;
            }
        }
    
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
