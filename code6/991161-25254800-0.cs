    using System;
    
    namespace excel_array_sent
    {
        class Program
        {
            static void Main(string[] args)
            {
    /* --------------------------------------------------------------------------------------------- */
                string str = "DNO";
                string str2 = "DNO";
                string str3 = "DNO";
                string str4 = "DNO";
                string str5 = "DNO";
    
                // Для получения значений равное 4
                int value1_4 = 4;
                int value2_4 = 8;
                int value3_4 = 12;
                int value4_4 = 16;
                int value5_4 = 20;
                string[] arr1_4 = new string[value1_4];
                string[] arr2_4 = new string[value2_4];
                string[] arr3_4 = new string[value3_4];
                string[] arr4_4 = new string[value4_4];
                string[] arr5_4 = new string[value5_4];
    
                // Для получения значений равное 3
                int value1_3 = 3;
                int value2_3 = 7;
                int value3_3 = 11;
                int value4_3 = 15;
                int value5_3 = 19;
                string[] arr1_3 = new string[value1_3];
                string[] arr2_3 = new string[value2_3];
                string[] arr3_3 = new string[value3_3];
                string[] arr4_3 = new string[value4_3];
                string[] arr5_3 = new string[value5_3];
    
                // Для получения значений равное 2
                int value1_2 = 2;
                int value2_2 = 6;
                int value3_2 = 10;
                int value4_2 = 14;
                int value5_2 = 18;
                string[] arr1_2 = new string[value1_2];
                string[] arr2_2 = new string[value2_2];
                string[] arr3_2 = new string[value3_2];
                string[] arr4_2 = new string[value4_2];
                string[] arr5_2 = new string[value5_2];
    
                // Для получения значений равное 1
                int value1_1 = 1;
                int value2_1 = 5;
                int value3_1 = 9;
                int value4_1 = 13;
                int value5_1 = 17;
                string[] arr1_1 = new string[value1_1];
                string[] arr2_1 = new string[value2_1];
                string[] arr3_1 = new string[value3_1];
                string[] arr4_1 = new string[value4_1];
                string[] arr5_1 = new string[value5_1];
    /* --------------------------------------------------------------------------------------------- */
    
                for(int i = 0; i < value1_3; i++)
                {
                    Console.Write(i.ToString() + "%");
                    arr1_4[i] = str;
                    write_excel(arr1_4);
                }
    
                for (int i = value1_4; i < value2_3; i++)
                {
                    Console.Write(i.ToString() + "%");
                    arr2_4[i] = str2;
                    write_excel2(arr2_4);
                }
    
                for (int i = value2_4; i < value3_3; i++)
                {
                    Console.Write(i.ToString() + "%");
                    arr3_4[i] = str3;
                    write_excel3(arr3_4);
                }
            }
    
            public static void write_excel(string[] str)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
                    ObjExcel.Visible = false;
                    ObjExcel.UserControl = true;
                    ObjExcel.DisplayAlerts = false;
                    ObjWorkBook = ObjExcel.Workbooks.Open("C:\\Шаблон.xls");
                    ObjWorkSheet = ObjWorkBook.Sheets[3];
    
                    int iNums = str.Length;
    
                    switch (iNums)
                    {
                        case 1:
                            {
                                ObjWorkSheet.Cells[4, 4] = str[0];
                                break;
                            }
                        case 2:
                            {
                                ObjWorkSheet.Cells[4, 4] = str[0];
                                ObjWorkSheet.Cells[5, 4] = str[1];
                                break;
                            }
                        case 3:
                            {
                                ObjWorkSheet.Cells[4, 4] = str[0];
                                ObjWorkSheet.Cells[5, 4] = str[1];
                                ObjWorkSheet.Cells[6, 4] = str[2];
                                break;
                            }
    
                        case 4:
                            {
                                ObjWorkSheet.Cells[4, 4] = str[0];
                                ObjWorkSheet.Cells[5, 4] = str[1];
                                ObjWorkSheet.Cells[6, 4] = str[2];
                                ObjWorkSheet.Cells[7, 4] = str[3];
                                break;
                            }
                    }
    
                    ObjWorkBook.SaveAs("C:\\Шаблон_Изменен.xls");
                    ObjExcel.Quit();
                }
    
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
    
            public static void write_excel2(string[] str)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
                    ObjExcel.Visible = false;
                    ObjExcel.UserControl = true;
                    ObjExcel.DisplayAlerts = false;
                    ObjWorkBook = ObjExcel.Workbooks.Open("C:\\Шаблон_Изменен.xls");
                    ObjWorkSheet = ObjWorkBook.Sheets[3];
    
                    int iNums = str.Length;
    
                    switch (iNums)
                    {
                        case 5:
                            {
                                ObjWorkSheet.Cells[8, 4] = str[4];
                                break;
                            }
                        case 6:
                            {
                                ObjWorkSheet.Cells[8, 4] = str[4];
                                ObjWorkSheet.Cells[9, 4] = str[5];
                                break;
                            }
                        case 7:
                            {
                                ObjWorkSheet.Cells[8, 4] = str[4];
                                ObjWorkSheet.Cells[9, 4] = str[5];
                                ObjWorkSheet.Cells[10, 4] = str[6];
                                break;
                            }
    
                        case 8:
                            {
                                ObjWorkSheet.Cells[8, 4] = str[4];
                                ObjWorkSheet.Cells[9, 4] = str[5];
                                ObjWorkSheet.Cells[10, 4] = str[6];
                                ObjWorkSheet.Cells[11, 4] = str[7];
                                break;
                            }
                    }
    
                    ObjWorkBook.Save();
                    ObjExcel.Quit();
                }
    
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
    
            public static void write_excel3(string[] str)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
                    ObjExcel.Visible = false;
                    ObjExcel.UserControl = true;
                    ObjExcel.DisplayAlerts = false;
                    ObjWorkBook = ObjExcel.Workbooks.Open("C:\\Шаблон_Изменен.xls");
                    ObjWorkSheet = ObjWorkBook.Sheets[3];
    
                    int iNums = str.Length;
    
                    switch (iNums)
                    {
                        case 9:
                            {
                                ObjWorkSheet.Cells[12, 4] = str[8];
                                break;
                            }
                        case 10:
                            {
                                ObjWorkSheet.Cells[12, 4] = str[8];
                                ObjWorkSheet.Cells[13, 4] = str[9];
                                break;
                            }
                        case 11:
                            {
                                ObjWorkSheet.Cells[12, 4] = str[8];
                                ObjWorkSheet.Cells[13, 4] = str[9];
                                ObjWorkSheet.Cells[14, 4] = str[10];
                                break;
                            }
    
                        case 12:
                            {
                                ObjWorkSheet.Cells[12, 4] = str[8];
                                ObjWorkSheet.Cells[13, 4] = str[9];
                                ObjWorkSheet.Cells[14, 4] = str[10];
                                ObjWorkSheet.Cells[15, 4] = str[11];
                                break;
                            }
                    }
    
                    ObjWorkBook.Save();
                    ObjExcel.Quit();
                }
    
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
    }
