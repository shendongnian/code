       if(callrec !=null)
                   {
                     DataTable dt = new DataTable();
                      dt.Columns.AddRange(new DataColumn[7] {
                        new DataColumn("RECORDING FILE NAME",typeof(string)),
                        new DataColumn("ACCOUNT NUMBER",typeof(string)),
                        new DataColumn("CALL START TIME",typeof(string)),
                        new DataColumn("AGENT NAME",typeof(string)),
                        new DataColumn("AGENT RESULT",typeof(string)),
                        new DataColumn("DURATION SECONDS",typeof(string)),
                        new DataColumn("PHONE DIALED",typeof(string))
                    });
                    foreach (var item in callrec)
                    {
                        dt.Rows.Add(item.RecFileName,
                            item.AccountNo == "NULL" ? "":item.AccountNo,
                           item.CallStartTime == null ? null : item.CallStartTime,
                           item.agentName=="NULL"? "":item.agentName,
                           item.agentResults=="NULL"?"":item.agentResults,
                           item.DurationSecs,
                           item.phoneDialed=="NULL"?"":item.phoneDialed
                        );
                    };
                    //Code For Closed XML
                    using ( XLWorkbook wb= new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add(dt, "CallRecordingData");
                        ws.Tables.FirstOrDefault().ShowAutoFilter = false;
                        MemoryStream stream = GetStream(wb);
                       // Response.Clear();
                       // Response.Buffer = true;
                       // Response.Charset = "";
                       // Response.ContentType = "application/vnd.openxmlformats- 
        officedocument.spreadsheetml.sheet";
                       // Response.AddHeader("content-disposition", 
           "attachment;filename=" + fileName + ".xlsx");
                    }
                }
