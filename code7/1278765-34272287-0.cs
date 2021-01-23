    Control c2 = this.ReportTable.GetControlFromPosition(col,row+1);
                                      Trace.WriteLine(c2.GetType());
                                      if (c2.GetType().Equals(typeof(TableLayoutPanel)))
                                      {
                                          TableLayoutPanel tp = (TableLayoutPanel)c2;
                                          
                                          // get all labels in table  
                                          foreach(Control ctr in tp.Controls){
                                              Trace.WriteLine(ctr .GetType());
                                          }
                                          
                                      }
