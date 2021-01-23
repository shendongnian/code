    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication4
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private void Form1_Load(object sender, EventArgs e)
    		{
    			var listCountry = new List<Country>() {
    				new Country() {ID = "UK", Name = "United Kingdom"},
    				new Country() {ID = "US", Name = "United States of America"},
    			};
    
    			comboBox1.DataSource = listCountry;
    			comboBox1.DisplayMember = "Name";
    			comboBox1.ValueMember = "ID";
    		}
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			MessageBox.Show(comboBox1.SelectedValue.ToString());
    		}
    	}
    
    	public class Country
    	{
    		public string ID { get; set; }
    		public string Name { get; set; }
    	}
    }
