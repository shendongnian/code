    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.OleDb;
    using System.Xml;
    using System.Xml.Xsl;
    namespace CSVImporter
    {
        public partial class CSVImporter : Form
        {
            //const string xmlfilename = @"C:\Users\fenwky\XmlDoc.xml";
            const string xmlfilename = @"C:\temp\test.xml";
            DataSet ds = null;
            public CSVImporter()
            {
                InitializeComponent();
                // Create a Open File Dialog Object.
                openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog1.ShowDialog();
                string fileName = openFileDialog1.FileName;
                //doc.InsertBefore(xDeclare, root);
                // Create a CSV Reader object.
                CSVReader reader = new CSVReader();
                ds = reader.ReadCSVFile(fileName, true);
                dataGridView1.DataSource = ds.Tables["Table1"];
            }
            private void WXML_Click(object sender, EventArgs e)
            {
                WriteXML();
            }
            public void WriteXML()
            {
     
                StringWriter stringWriter = new StringWriter();
                ds.WriteXml(new XmlTextWriter(stringWriter), XmlWriteMode.WriteSchema);
                string xmlStr = stringWriter.ToString();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlStr);
                XmlDeclaration xDeclare = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.InsertBefore(xDeclare, doc.FirstChild);
                // Create a procesing instruction.
                //XmlProcessingInstruction newPI;
                //String PItext = "<abc:stylesheet xmlns:abc=\"http://www.w3.org/1999/XSL/Transform\" version=\"1.0\">";
                //String PItext = "type='text/xsl' href='book.xsl'";
                string PItext = "html xsl:version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\"";
                XmlText newPI =  doc.CreateTextNode(PItext);
                //newPI = docCreateProcessingInstruction("html", PItext);
                //newPI = doc.CreateComment(CreateDocumentType("html", PItext, "", "");
                doc.InsertAfter(newPI, doc.FirstChild);
                doc.Save(xmlfilename);
                XslCompiledTransform myXslTrans = new XslCompiledTransform();
                myXslTrans.Load(xmlfilename);
                string directoryPath = Path.GetDirectoryName(xmlfilename);
                myXslTrans.Transform(xmlfilename, directoryPath + "result.html");
                webBrowser1.Navigate(directoryPath + "result.html");
            }
     
     
        }
        public class CSVReader
        {
            public DataSet ReadCSVFile(string fullPath, bool headerRow)
            {
                string path = fullPath.Substring(0, fullPath.LastIndexOf("\\") + 1);
                string filename = fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
                DataSet ds = new DataSet();
                try
                {
                    if (File.Exists(fullPath))
                    {
                        string ConStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}" + ";Extended Properties=\"Text;HDR={1};FMT=Delimited\\\"", path, headerRow ? "Yes" : "No");
                        string SQL = string.Format("SELECT * FROM {0}", filename);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(SQL, ConStr);
                        adapter.Fill(ds, "TextFile");
                        ds.Tables[0].TableName = "Table1";
                    }
                    foreach (DataColumn col in ds.Tables["Table1"].Columns)
                    {
                        col.ColumnName = col.ColumnName.Replace(" ", "_");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return ds;
            }
        }
    }
