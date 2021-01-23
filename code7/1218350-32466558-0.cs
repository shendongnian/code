    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //~~> Define your Excel Objects
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook;
                //~~> Start Excel and open the workbook.
                xlWorkBook = xlApp.Workbooks.Open("E:\\Users\\Siddharth Rout\\Desktop\\book1.xlsm");
                //~~> Run the macros by supplying the necessary arguments
                xlApp.Run("test");
                //~~> Clean-up: Close the workbook
                xlWorkBook.Close(false);
                //~~> Quit the Excel Application
                xlApp.Quit();
                //~~> Clean Up
                releaseObject(xlApp);
                releaseObject(xlWorkBook);
            }
            //~~> Release the objects
            private void releaseObject(object obj)
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
                catch (Exception ex)
                {
                    obj = null;
                }
                finally
                {
                    GC.Collect();
                }
            }
        }
    }
