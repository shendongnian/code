    foreach (var item in list_ban)
    {
                
           string rtbpicker = item.ToString();
                
           foreach (var comp in list_Comp)
           {
                   
               foreach (Match m in Regex.Matches(rtbpicker, "" + comp.ToString() + ""))
               {
                        
                   int matchindex = m.Index;
                   int matchlength = m.Length;
                        
                   rtbpicker = rtbpicker.Insert(matchindex + matchlength, " ");
                            
                        
                }
                    
           }
                richTextBox6.Text += rtbpicker + "\n";
                //rtbBan.AppendText(rtbpicker + System.Environment.NewLine);
    }
