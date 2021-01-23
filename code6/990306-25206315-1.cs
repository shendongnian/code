       foreach (string line in lines)
       {
          RawData temp = new RawData(line);
          var AllAccounts = temp.AccountNoDv.split(' ');
          var Amts = temp.Amt.split(' ');
          if (AllAccounts.Length() == Amts.Length() && Amts.Length() > 1) {
            // We have multiple values!
            reduced++;
            for (int i = 0; i < AllAccounts.Length(); i++) {
              RawData temp2 = RawDataCopy(temp); // Copy the RawData object
              temp2.AccountNoDv = AllAccounts[i];
              temp2.Amt = Amts[i];
              total++;
              data.Add(temp2);
            }
          }
          else {
            total++;
            if (!(temp.FirstAccount.Length == 0 || temp.FirstAccount == "1ST-ACCT-NO"))
            {
               reduced++;
               data.Add(temp);
             }
           }
        }
