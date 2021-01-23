    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace ListBoxSearch_cs
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {
                var results =
                    ((List<Item>)ListBox1.DataSource)
                        .Select((data, index) => new 
                        { Text = data.SerialNumber, Index = index })
                        .Where((data) => data.Text == "BB1").FirstOrDefault();
                if (results != null)
                {
                    ListBox1.SelectedIndex = results.Index;
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var items = new List<Item>() {
    			new Item {Identifier = 1, SerialNumber = "AA1", Type = "A1"},
    			new Item {Identifier = 2, SerialNumber = "BB1", Type = "A1"},
    			new Item {Identifier = 3, SerialNumber = "CD12", Type = "XD1"}
    		};
                ListBox1.DisplayMember = "DisplayText";
                ListBox1.DataSource = items;
            }
        }
        /// <summary>
        /// Should be in it's own class file
        /// but done here to keep code together
        /// </summary>
        public class Item
        {
            public string SerialNumber { get; set; }
    
            public string Type { get; set; }
    
            public int Identifier { get; set; }
    
            public string DisplayText
            {
                get
                {
                    return SerialNumber + " " + this.Type;
                }
            }
        }
    }
