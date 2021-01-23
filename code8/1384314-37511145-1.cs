    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string url = "http://www.nbg.ge/rss.php";
            public Form1()
            {
                InitializeComponent();
                XElement rss = XElement.Load(url);
                DataTable dt = new DataTable();
                dt.Columns.Add("Currency", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Rate", typeof(decimal));
                XElement description = rss.Descendants("item").FirstOrDefault().Descendants("description").FirstOrDefault();
                string value = description.Value;
                value = Regex.Replace(value, "(src=\\\"[^\\\"]+\\\")", "$1/");
                XElement table = XElement.Parse(value);
                foreach (XElement row in table.Descendants("tr"))
                {
                    List<XElement> columns = row.Elements("td").ToList();
                    dt.Rows.Add(new object[] {(string)columns[0], (string)columns[1], (decimal)columns[2]});
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
