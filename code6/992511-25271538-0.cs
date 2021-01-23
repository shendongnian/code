	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Data;
	using Excel = Microsoft.Office.Interop.Excel;
	namespace ExcelDemo
	{
		public class ExcelUtility
		{
			public static void CreateExcel(DataSet ds, string excelPath)
			{
				Excel.Application xlApp;
				Excel.Workbook xlWorkBook;
				Excel.Worksheet xlWorkSheet;
				object misValue = System.Reflection.Missing.Value;
				try
				{
					xlApp = new Excel.ApplicationClass();
					xlWorkBook = xlApp.Workbooks.Add(misValue);
					xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
					for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
					{
						for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
						{
							xlWorkSheet.Cells[i + 1, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
						}
					}
					xlWorkBook.SaveAs(excelPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
					xlWorkBook.Close(true, misValue, misValue);
					xlApp.Quit();
					releaseObject(xlApp);
					releaseObject(xlWorkBook);
					releaseObject(xlWorkSheet);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			private static void releaseObject(object obj)
			{
				try
				{
					System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
					obj = null;
				}
				catch
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
