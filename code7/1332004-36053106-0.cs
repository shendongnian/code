    using System.Drawing;
    using System.Windows.Forms;
    using Spire.Pdf;
    using Spire.Doc;
    using Spire.Xls;
    using Spire.Presentation;
    using System.IO;
    using Spire.Pdf.Graphics;
    
    namespace ConvertAndMerge
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                PdfFiles = new List();
            }
            public List PdfFiles { get; set;}
    
            //Add files to listbox
            private void btnAdd_Click(object sender, EventArgs e)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All files (*.docx, *.pdf, *.pptx, *.pdf)|*.docx;*.pdf;*.pptx;*.xlsx";
                ofd.Multiselect=true;
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    string[] files = ofd.FileNames;
                    listBox1.Items.AddRange(files);
                }
            }
    
            private void btnMerge_Click(object sender, EventArgs e)
            {
                //Convert other file formats to PDF file
                string ext=string.Empty;
                foreach (object item in listBox1.Items)
                {
                    ext=Path.GetExtension(item.ToString());
                    switch (ext)
                    {
                        case ".docx":
                            using (MemoryStream ms = new MemoryStream())
                            {
                                Document doc = new Document(item.ToString());
                                doc.SaveToStream(ms, Spire.Doc.FileFormat.PDF);
                                PdfFiles.Add(new PdfDocument(ms));
                            }
                            break;
                        case ".pdf":
                            PdfFiles.Add(new PdfDocument(item.ToString()));
                            break;
                        case ".pptx":
                            using (MemoryStream ms = new MemoryStream())
                            {
                                Presentation ppt = new Presentation(item.ToString(),Spire.Presentation.FileFormat.Auto);
                                ppt.SaveToFile(ms,Spire.Presentation.FileFormat.PDF);
                                PdfFiles.Add(new PdfDocument(ms));
                            }
                            break;
                        case ".xlsx":
                            using (MemoryStream ms = new MemoryStream())
                            {
                                Workbook xls = new Workbook();
                                xls.LoadFromFile(item.ToString());
                                xls.SaveToStream(ms, Spire.Xls.FileFormat.PDF);
                                PdfFiles.Add(new PdfDocument(ms));
                            }
                            break;
                        default:
                            break;
                    }              
                }
                //Merge the PDF files into one PDF
                PdfDocument newPdf1 = new PdfDocument();
                foreach (PdfDocument doc in PdfFiles)
                {
                    newPdf1.AppendPage(doc);
                }
                //Create a new PDF with specified page size, copy the content of merged file to new PDF file
                PdfDocument newPdf2 = new PdfDocument();
                foreach (PdfPageBase page in newPdf1.Pages)
                {
                    PdfPageBase newPage = newPdf2.Pages.Add(PdfPageSize.A4, new PdfMargins(0));
                    PdfTextLayout loLayout = new PdfTextLayout();
                    loLayout.Layout = PdfLayoutType.OnePage;
                    page.CreateTemplate().Draw(newPage, new PointF(0, 0), loLayout);
                }
                //Save the destination PDF file
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Pdf files(*.pdf)|*.pdf";
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    newPdf2.SaveToFile(sfd.FileName);
                }
            }
        }
    }
