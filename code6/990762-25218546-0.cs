    // Declare the PrintDocument object.
    private System.Drawing.Printing.PrintDocument docToPrint; 
         //= new System.Drawing.Printing.PrintDocument();
    public Form1()   // the Form ctor
    {
       InitializeComponents();
       docToPrint = new System.Drawing.Printing.PrintDocument();
       docToPrint.PrintPage += document_PrintPage; // the missing piece
    }
