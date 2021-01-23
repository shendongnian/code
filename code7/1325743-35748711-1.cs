    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Schema;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            DataSet ds = new DataSet("Jobs");
            public Form1()
            {
                InitializeComponent();
                getJobsFromSource();
                DataTable dt = ds.Tables[0];
                dt = dt.AsEnumerable().GroupBy(x => x.Field <string>("jobkey")).Select(x => x.FirstOrDefault()).OrderBy(y => y.Field<string>("jobkey")).CopyToDataTable();
                dataGridView1.DataSource = dt;
            }
            public void getJobsFromSource()
    {
                string url = @"http://api.indeed.com/ads/apisearch?publisher=5566998848654317&v=2&q=%22%22&filter=1%22%22&limit=25";
                XmlDocument doc = new XmlDocument();
                doc.Load(url);
                int totalResults = int.Parse(doc.SelectSingleNode("response /totalresults").InnerText);
                for (int i = 0; i < totalResults; i += 25)
                {
                    string newUrl = @"http://api.indeed.com/ads/apisearch?publisher=5566998848654317&v=2&q=%22%22&filter=1&limit=25&start={i}";
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.None;
                    settings.IgnoreWhitespace = true;
                    XmlReader xmlReader = XmlReader.Create(newUrl, settings);
                    while (!xmlReader.EOF)
                    {
                        if (xmlReader.Name != "result")
                        {
                            xmlReader.ReadToFollowing("result");
                        }
                        if(!xmlReader.EOF)
                        {
                            ds.ReadXml(xmlReader);
                        }
                    }
                }
           }
        }
    }
       
