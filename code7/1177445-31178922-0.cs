    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                string input =
                "<ArrayOfReceiptTransfer_Receipt xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" + 
                  "<ReceiptTransfer_Receipt>" +
                    "<ReceiptTransfer_Receipt_ID>77491</ReceiptTransfer_Receipt_ID>" +
                    "<ReceiptTransferID>17839</ReceiptTransferID>" +
                    "<ReceiptID>74080</ReceiptID>" +
                    "<Amount>500.00</Amount>" +
                  "</ReceiptTransfer_Receipt>" +
                "</ArrayOfReceiptTransfer_Receipt>";
                string xml = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?><root>{0}</root>", input);
                StringReader reader = new StringReader(xml);
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                dataGridView1.DataSource = ds.Tables[1];
            }
        }
    }
    ​
