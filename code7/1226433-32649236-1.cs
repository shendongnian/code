    foreach (DataRow dr in dtCSVdata.Rows)
    {
     StringBuilder sbData = new StringBuilder();
    //comment Below line of codewhich is used to write data in database
    // SQLHelper.MoveOtherQuotesToWaitingArivalOfBags(quoteHeaderId, Config.WSUserName, refCode);
    foreach (object obj in dr.ItemArray)
    {
         if (sbData.Length == 0)
         {
             sbData.Append("\"");
             sbData.Append(RemoveSpecialCharacters(obj.ToString()));
             sbData.Append("\"");
         }
         else
         {
              sbData.Append(",");
              sbData.Append("\"");
              sbData.Append(RemoveSpecialCharacters(obj.ToString()));
              sbData.Append("\"");
         }
     }
     //Write to file
     writer.WriteLine(sbData.ToString());
     writer.close();//may use using 
     //after writing insert into database table.
     SQLHelper.MoveOtherQuotesToWaitingArivalOfBags(quoteHeaderId, Config.WSUserName, refCode);
    }
