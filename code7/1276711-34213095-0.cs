        private void btnExecute_Click(object sender, EventArgs e)
        {
            
            var word = new Microsoft.Office.Interop.Word.Application();
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelworkbook = excelApp.Workbooks.Open("D:\\myxlspreadsheet");
            Excel._Worksheet excelworkSheet = (Excel.Worksheet)excelApp.ActiveSheet;
            
          
            excelApp.Visible = true;
            
            object miss = System.Reflection.Missing.Value;
            object path = txbxFilePath1.Text;
            object readOnly = true;
            var docs = word.Documents.Open(ref path, ref miss, ref readOnly, 
                                       ref miss, ref miss, ref miss, ref miss, 
                                       ref miss, ref miss, ref miss, ref miss, 
                                       ref miss, ref miss, ref miss, ref miss, 
                                       ref miss);
            //Get the tables in the word Document
            foreach (Table tb in docs.Tables)
            {                
                for (int row = 1; row <= tb.Rows.Count; row++)
                {
                    for (int mycols = 1; mycols <= tb.Columns.Count; mycols++)
                    {
                        var cells = tb.Cell(row, mycols).Range.Paragraphs;
                        
                        //Create a List using your custom formatter Class
                        List<Formatter> lFormatter = new List<Formatter>();                   
                        foreach (Paragraph para in cells)
                        {
                            Formatter formatter = new Formatter();
                            formatter.strCellText = para.Range.Text;
                            formatter.flIndent = para.LeftIndent;
                            formatter.strBullet = para.Range.ListFormat.ListString;
                            rTxBxResult.AppendText(formatter.strCombine);
                            lFormatter.Add(formatter);
                        }
                        for (int i =0; i< lFormatter.Count; i++)
                        {
                            Formatter formatter = lFormatter[i];
                            if(i==0)
                                excelworkSheet.Cells[row, mycols] = ((string)(excelworkSheet.Cells[row, mycols] as Excel.Range).Value2) + formatter.strCombine;
                            else
                                excelworkSheet.Cells[row, mycols] = ((string)(excelworkSheet.Cells[row, mycols] as Excel.Range).Value2) + Environment.NewLine + formatter.strCombine;
                        }
                        
                    }                    
                }
            }
        }
     
    }
    //Use this class to store the collected values from the rows and colums of the word table
    public class Formatter
    {
        public string strCellText;
        public string strIndent = "";
        public float flIndent;
        public string strBullet;
        //Combine the pieces together and manipulate the strings as needed
        public string strCombine
        {
            get 
            {
                //first indent is 36 so 1 tab, second indent is 72 so 2 tabs, etc
                //alternate * and dashes for bullet marks in excel using odd and even numbers
                decimal newIndent = Math.Round((decimal)(flIndent / 36));
                for (int i = 0; i < newIndent; i++)
                {
                    strIndent = strIndent + "  ";
                }
                if (newIndent == 0)
                    strBullet = "";
                else if (IsOdd((int)newIndent))
                    strBullet="*";
                else
                    strBullet = "-";
                return strIndent + strBullet + strCellText;                
            }
        }
        
        public static bool IsOdd(int value)
        {
	    return value % 2 != 0;
        }
       
    }
