    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace Full_Profile1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
                //This is the absolute path to the PDF that we will create
                string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sample.pdf");
    
                //Create a standard .Net FileStream for the file, setting various flags
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //Create a new PDF document setting the size to A4
                    using (Document doc = new Document(PageSize.A4))
                    {
                        //Bind the PDF document to the FileStream using an iTextSharp PdfWriter
                        using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                        {
                            //Open the document for writing
                            doc.Open();
    
                            //Create a table with two columns
                            PdfPTable t = new PdfPTable(2);
    
                            //Borders are drawn by the individual cells, not the table itself.
                            //Tell the default cell that we do not want a border drawn
                            t.DefaultCell.Border = 0;
    
                            //Add four cells. Cells are added starting at the top left of the table working left to right first, then down
                            t.AddCell("R1C1");
                            t.AddCell("R1C2");
                            t.AddCell("R2C1");
                            t.AddCell("R2C2");
    
                            //Add the table to our document
                            doc.Add(t);
    
                            //Close our document
                            doc.Close();
                        }
                    }
                }
    
                this.Close();
            }
        }
    }
