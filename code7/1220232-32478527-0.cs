    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    using VBIDE = Microsoft.Vbe.Interop;
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Excel.Application xlexcel;
                Excel.Workbook xlWorkBook;
                VBIDE.VBComponent newStandardModule;
                VBIDE.CodeModule codeModule;
                object misValue = System.Reflection.Missing.Value;
                const string excelFile = @"C:\Users\Siddharth\Desktop\Sid.xlsm";
                xlexcel = new Excel.Application();
                xlexcel.Visible = true;
                // Open a File
                xlWorkBook = xlexcel.Workbooks.Open(excelFile, misValue, 
                             misValue, misValue, misValue, misValue, misValue,
                             misValue, misValue, misValue, misValue, misValue, 
                             misValue, misValue, misValue);
                newStandardModule = xlWorkBook.VBProject.VBComponents.Add(
                                    VBIDE.vbext_ComponentType.vbext_ct_StdModule);
                codeModule = newStandardModule.CodeModule;
                // add vba code to module
                var lineNum = codeModule.CountOfLines + 1;
                var macroName = "test";
                var codeText = "Sub " + macroName + "()" + "\r\n";
                codeText +=    "    Dim xsheet As Worksheet" + "\r\n";
                codeText +=    "    For Each xsheet In ThisWorkbook.Worksheets" + "\r\n";
                codeText +=    "        xsheet.UsedRange.Value = xsheet.UsedRange.Value" + "\r\n";
                codeText +=    "    Next xsheet" + "\r\n";
                codeText +=    "End Sub";
                codeModule.InsertLines(lineNum, codeText);
                xlWorkBook.Save();
                // run the macro
                var macro = string.Format("{0}!{1}.{2}", xlWorkBook.Name, newStandardModule.Name, macroName);
                xlexcel.Run(macro,misValue, misValue, misValue,misValue, misValue, misValue,
                misValue, misValue, misValue, misValue, misValue, misValue,   misValue, misValue, misValue,
                misValue, misValue, misValue, misValue, misValue, misValue,  misValue, misValue, misValue,
                misValue, misValue, misValue, misValue, misValue, misValue);
                xlexcel.Quit();
            }
        }
    }
