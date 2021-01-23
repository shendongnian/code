    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Linq;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                string xml =
                "<Root>" +
                   "<row>" +
                   "<c24>20160201</c24>" +
                   "<c24 m=\"2\">20160131</c24>" +
                   "<c24 m=\"3\">20160101</c24>" +
                   "<c24 m=\"4\">20151231</c24>" +
                   "<c24 m=\"5\">20151201</c24>" +
                   "<c24 m=\"6\">20151130</c24>" +
                   "<c24 m=\"7\">20151102</c24>" +
                   "</row>" +
                   "<row>" +
                   "<c28>IN</c28>" +
                   "<c28 m=\"1\" s=\"2\">PE</c28>" +
                   "<c28 m=\"1\" s=\"3\">PS</c28>" +
                   "<c28 m=\"2\">PR</c28>" +
                   "<c28 m=\"2\" s=\"2\">PE</c28>" +
                   "<c28 m=\"2\" s=\"3\">PS</c28>" +
                   "<c28 m=\"3\">IN</c28>" +
                   "<c28 m=\"3\" s=\"2\">PE</c28>" +
                   "<c28 m=\"3\" s=\"3\">PS</c28>" +
                   "<c28 m=\"3\" s=\"4\">CE</c28>" +
                   "<c28 m=\"3\" s=\"5\">CS</c28>" +
                   "<c28 m=\"4\">PR</c28>" +
                   "<c28 m=\"4\" s=\"2\">PE</c28>" +
                   "<c28 m=\"4\" s=\"3\">PS</c28>" +
                   "<c28 m=\"4\" s=\"4\">CE</c28>" +
                   "<c28 m=\"4\" s=\"5\">CS</c28>" +
                   "<c28 m=\"5\">IN</c28>" +
                   "<c28 m=\"5\" s=\"2\">PE</c28>" +
                   "<c28 m=\"5\" s=\"3\">PS</c28>" +
                   "<c28 m=\"5\" s=\"4\">CE</c28>" +
                   "<c28 m=\"5\" s=\"5\">CS</c28>" +
                   "<c28 m=\"6\">PR</c28>" +
                   "<c28 m=\"6\" s=\"2\">PE</c28>" +
                   "<c28 m=\"6\" s=\"3\">PS</c28>" +
                   "<c28 m=\"6\" s=\"4\">CE</c28>" +
                   "<c28 m=\"6\" s=\"5\">CS</c28>" +
                   "<c28 m=\"7\">PR</c28>" +
                   "<c28 m=\"7\" s=\"2\">PE</c28>" +
                   "<c28 m=\"7\" s=\"3\">PS</c28>" +
                   "<c28 m=\"7\" s=\"4\">CE</c28>" +
                   "<c28 m=\"7\" s=\"5\">CS</c28>" +
                   "</row>" +
                   "<row>" +
                   "<c29>1334.564</c29>" +
                   "<c29 m=\"1\" s=\"2\">9.509</c29>" +
                   "<c29 m=\"1\" s=\"3\">3.003</c29>" +
                   "<c29 m=\"2\">3900</c29>" +
                   "<c29 m=\"2\" s=\"2\">28.817</c29>" +
                   "<c29 m=\"2\" s=\"3\">9.1</c29>" +
                   "<c29 m=\"3\">1366.468</c29>" +
                   "<c29 m=\"3\" s=\"2\">10.097</c29>" +
                   "<c29 m=\"3\" s=\"3\">3.189</c29>" +
                   "<c29 m=\"3\" s=\"4\">10.818</c29>" +
                   "<c29 m=\"3\" s=\"5\">3.416</c29>" +
                   "<c29 m=\"4\">3900</c29>" +
                   "<c29 m=\"4\" s=\"2\">28.817</c29>" +
                   "<c29 m=\"4\" s=\"3\">9.1</c29>" +
                   "<c29 m=\"4\" s=\"4\">31.904</c29>" +
                   "<c29 m=\"4\" s=\"5\">10.075</c29>" +
                   "<c29 m=\"5\">1353.571</c29>" +
                   "<c29 m=\"5\" s=\"2\">10.001</c29>" +
                   "<c29 m=\"5\" s=\"3\">3.159</c29>" +
                   "<c29 m=\"5\" s=\"4\">21.789</c29>" +
                   "<c29 m=\"5\" s=\"5\">6.881</c29>" +
                   "<c29 m=\"6\">3900</c29>" +
                   "<c29 m=\"6\" s=\"2\">28.817</c29>" +
                   "<c29 m=\"6\" s=\"3\">9.1</c29>" +
                   "<c29 m=\"6\" s=\"4\">63.808</c29>" +
                   "<c29 m=\"6\" s=\"5\">20.15</c29>" +
                   "<c29 m=\"7\">1290.211</c29>" +
                   "<c29 m=\"7\" s=\"2\">9.533</c29>" +
                   "<c29 m=\"7\" s=\"3\">3.011</c29>" +
                   "<c29 m=\"7\" s=\"4\">30.641</c29>" +
                   "<c29 m=\"7\" s=\"5\">9.678</c29>" +
                   "</row>" +
                   "</Root>";
                XDocument doc = XDocument.Parse(xml);
                var results = doc.Descendants().Where(m => (m.Name.LocalName != "row") && (m.Name.LocalName != "Root"))
                    .GroupBy(x => x.Name.LocalName)
                    .Select(y => new
                    {
                        name = y.Where(z => z.Attribute("m") == null).Select(a => a.Value).FirstOrDefault(),
                        months = y.Where(z => z.Attribute("m") != null).GroupBy(z => z.Attribute("m")).Select(a => new
                        {
                            month = (int)a.Key,
                            section = a.Select(b => new
                            {
                                s = b.Attribute("s") == null ? null : (int?)b.Attribute("s"),
                                value = b.Value
                            }).FirstOrDefault()
                        }).ToList()
                    }).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Month", typeof(int));
                dt.Columns.Add("Section", typeof(int));
                dt.Columns.Add("Value", typeof(string));
                foreach (var name in results.AsEnumerable())
                {
                    foreach (var month in name.months.AsEnumerable())
                    {
                        if (month.section.s == null)
                        {
                            DataRow newRow = dt.Rows.Add(new object[] { name.name, month.month, 1, month.section.value });
                        }
                        else
                        {
                            DataRow newRow = dt.Rows.Add(new object[] { name.name, month.month, month.section.s, month.section.value });
                        }
                    }
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
