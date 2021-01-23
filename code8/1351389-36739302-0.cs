    List<Sheet1_> crmAccountList = new List<Sheet1_>();
    
                //var crmAccount = db.Sheet1_.Select(x => x).ToList().Take(2);
                var crmAccounts = db.Sheet1_.Select(x => x).ToList();
    
    
                foreach (var dbAccount in crmAccounts)
                {
                    CRMDataObject modelObject = new CRMDataObject()
                    {
                        ID = dbAccount.ID,
                        Account_No = dbAccount.Account_No,
                        Tax_No = dbAccount.Tax_No.ToString(),
                        Reg_No = dbAccount.Reg_No
                        //Tarsus_Country = dbAccount.Main_Phone
                    };
    
                }
    
                var officialDatabaseList = crmAccounts;
    
                foreach (var crmAcc in officialDatabaseList)
                {
                    QueryExpression qe = new QueryExpression();
                    qe.EntityName = "account";
                    qe.ColumnSet = new ColumnSet("accountnumber", "new_vatno", "new_registrationnumber");
                    qe.Criteria.AddCondition("accountnumber", ConditionOperator.In,'list of account numbers go here'
    
      EntityCollection response = service.RetrieveMultiple(qe);
    
                    foreach (var acc in response.Entities)
                    {
                        if (crmAcc.Account_No == acc.Attributes["accountnumber"].ToString())
                        {
                            //acc.Attributes["new_vatno"] = crmAcc.VAT_No.ToString();
                            acc.Attributes["new_registrationnumber"] = crmAcc.Reg_No.ToString();
    
                            service.Update(acc);
                        }
    
                    }
                }
