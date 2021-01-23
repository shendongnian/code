     public partial class Form1 : Form
        {
            //string to print
            private string stringToPrint = "Hello\r\nWorld\r\n\r\n<<< Page >>>World\r\nHello";
            //list of strings/pages
            private List<string> pageData = new List<string>();
            //enumerator for iteration thru "pages"
            private IEnumerator pageEnumerator;
            //print document
            PrintDocument printDocument1;
    
            public Form1()
            {
                InitializeComponent();
                         
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                
                //  Connect to the printer
                printDocument1 = new PrintDocument();
                //handle events
                printDocument1.BeginPrint += new PrintEventHandler(BeginPrint);
                printDocument1.PrintPage += new PrintPageEventHandler(PrintPage);
    
    
                try
                {
                    //do print
                    printDocument1.Print();
                    printDocument1.Dispose();
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured While Printing", ex);
                }
                
            }
    
            void BeginPrint(object sender, PrintEventArgs e)
            {
                //  Convert string to strings
                string[] seperatingChars = { "<<< Page >>>" };
                 
                //generate some dummy strings to print
                pageData = stringToPrint.Split(seperatingChars, System.StringSplitOptions.RemoveEmptyEntries).ToList();
    
                // get enumerator for dummy strings
                pageEnumerator = pageData.GetEnumerator();
    
                //position to first string to print (i.e. first page)
                pageEnumerator.MoveNext(); 
            }
    
            private void PrintPage(object sender, PrintPageEventArgs e)
            {
                //define font, brush, and print area
                Font font = new Font("Times New Roman", 12);
                Brush brush = Brushes.Black;
                RectangleF area = new RectangleF(0, 0, printDocument1.DefaultPageSettings.PrintableArea.Width,
                        printDocument1.DefaultPageSettings.PrintableArea.Height);
    
                //print current page
                e.Graphics.DrawString(pageEnumerator.Current.ToString(), font, brush, area);
    
                // advance enumerator to determine if we have more pages.
                e.HasMorePages = pageEnumerator.MoveNext();
    
            }
    
     
        }
