            Excel.Application xlApp = new Excel.Application();  //creates the application
            xlApp.Visible = true;   //change to false for final version
            
            string wbPath = @"C:\path.xlsx"; //sets the path
            Excel.Workbook xlWb = xlApp.Workbooks.Open(wbPath,
                0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                true, false, 0, true, false, false);
            //creates the workbook and opens the specific file
            Excel.Worksheet xlWS = (Excel.Worksheet)xlWb.ActiveSheet;   //sets the active sheet
            Excel.Range gr1Text = xlWS.get_Range("e20"); 
            Excel.Range xlRngP19 = xlWS.get_Range("p19");
            Excel.Range xlRngQ19 = xlWS.get_Range("q19");
            xlRngP19.Value = gr1Text;
            string[] rating = { "Exceptional", "Demonstrates skill level necessary for position", "Needs Improvement", "N/A" };
            bool opt1;
            opt1 = xlApp.ActiveSheet.OptionButton2.Value;
            bool opt2;
            opt2 = xlApp.ActiveSheet.OptionButton1.Value;
            bool opt3;
            opt3 = xlApp.ActiveSheet.OptionButton3.Value;
            bool opt4;
            opt4 = xlApp.ActiveSheet.OptionButton4.Value;
            bool chBox1;
            chBox1 = xlApp.ActiveSheet.CheckBox1.Value;
            Excel.Range xlRngP20 = xlWS.get_Range("p20");
            if (opt1 == true)
            {
                xlRngP20.Value = rating[0];
            }
            else if (opt2 == true)
            {
                xlRngP20.Value = rating[1];
            }
            else if (opt3 == true)
            {
                xlRngP20.Value = rating[2];
            }
            else if (opt4 == true)
            {
                xlRngP20.Value = rating[3];
            }
            else 
            {
                xlRngP20.Value = "**NOT RECORDED**";
            }
            if (chBox1 == true)
            {
                xlRngQ19.Value = "Growth Opportunity";
            }
            
            xlWb.Close(true);
            xlApp.Quit();
            //closes the file
