    Summary summary = new Summary();
                    if (str1 == "Influx" && str1 != "Grand Total")
                    {
                        for (rCnt = rCnt + 7; rCnt < range.Rows.Count; rCnt++)
                        {
                            str = (string)(range.Cells[rCnt, 1] as Excel.Range).Text;
                            if (str == "VMS")
                            {                                
                                summary.VMS = xlWorkSheet.Cells[rCnt, 5].Text;
                            }
                            if (str == "eService")
                            {
                                summary.eService = xlWorkSheet.Cells[rCnt, 5].Text;
                            }
                            if (str == "RES")
                            {
                                summary.Res = xlWorkSheet.Cells[rCnt, 5].Text;
                            }
                            if (str == "RSC")
                            {
                                summary.RSC = xlWorkSheet.Cells[rCnt, 5].Text;
                            }
                            if (str == "VFS")
                            {
                                summary.VFS = xlWorkSheet.Cells[rCnt, 5].Text;
                            }
                            if (str == "SYS 80")
                            {
                                summary.System80 = xlWorkSheet.Cells[rCnt, 5].Text;
                            }
                            if (str == "HCL")
                            {
                                summary.HCL = xlWorkSheet.Cells[rCnt, 5].Text;
                            }
                            if (str == "Others")
                            {
                                summary.Others = xlWorkSheet.Cells[rCnt, 5].Text;
                            }
                        }
                        break;
                    }
     //while fetching the vaues of each property having some value is the below code,instead of hardcoding the index of each property which has some value, i want to store it somewhere and then fetch it while writing the values in a cell.
    xlWorkSheet.Cells[iCount, jCount] = summary.VMS;        //Daily influx
    xlWorkSheet.Cells[iCount + 2, jCount] = Convert.ToString(Convert.ToInt32(OnHold[0].VMS)-Convert.ToInt32(xlWorkSheet.Cells[iCount+4,jCount-1].Text)); //Tickets moved to hold    
    xlWorkSheet.Cells[iCount+3, jCount] = Active[0].VMS;     // Ending Backlog
    xlWorkSheet.Cells[iCount + 4, jCount] = OnHold[0].VMS;   //Ending Hold
