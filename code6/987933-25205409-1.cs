    foreach (var item in list_ban)
    {
                
           string rtbpicker = item.ToString();
                
           foreach (var comp in list_Comp)
           {
                   
               int count = 0; //Counts for the number of occurences
               foreach (Match m in Regex.Matches(rtbpicker, "" + comp.ToString() + ""))
               {
                        
                   int matchindex = m.Index;
                   int matchlength = m.Length;
                        
                   rtbpicker = rtbpicker.Insert(matchindex + matchlength + count, " "); //Count just moves the index forward by however many postions the original index was shifted
                   
                   if(Regex.Matches(rtbpicker, "" + comp.ToString() + "").Count > 1)
                   {
                      count++;
                                
                   }         
                        
                }
                    
           }
                richTextBox6.Text += rtbpicker + "\n";
                //rtbBan.AppendText(rtbpicker + System.Environment.NewLine);
    }
