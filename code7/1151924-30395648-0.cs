    using System;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    Namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            Public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Excel.Application xlexcel;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                                       
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Excel.Application();
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlexcel.Visible = true;
    
                //add data
                xlWorkSheet.Cells[1, 1] = 1;
                xlWorkSheet.Cells[2, 1] = 2;
                xlWorkSheet.Cells[3, 1] = 3;
                xlWorkSheet.Cells[4, 1] = 4;
    
                Excel.Range MyRange = xlWorkSheet.get_Range("A1", "A4");
                           
                MyRange.FormatConditions.AddIconSetCondition();
                MyRange.FormatConditions.Item (MyRange.FormatConditions.Count).SetFirstPriority();
                MyRange.FormatConditions.Item(1).ReverseOrder = false;
                MyRange.FormatConditions.Item(1).ShowIconOnly = false;
                MyRange.FormatConditions.Item(1).IconSet = xlWorkBook.IconSets[Excel.XlIconSet.xl3TrafficLights2];
    
                MyRange.FormatConditions.Item(1).IconCriteria(2).Type = Excel.XlConditionValueTypes.xlConditionValuePercent;
                MyRange.FormatConditions.Item(1).IconCriteria(2).Value = 33;
                MyRange.FormatConditions.Item(1).IconCriteria(2).Operator = 7;
    
                MyRange.FormatConditions.Item(1).IconCriteria(3).Type = Excel.XlConditionValueTypes.xlConditionValuePercent;
                MyRange.FormatConditions.Item(1).IconCriteria(3).Value = 67;
                MyRange.FormatConditions.Item(1).IconCriteria(3).Operator = 7;
                
                // Rest of the code
            }
        }
    }
