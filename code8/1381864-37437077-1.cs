    public static void UpdateAllCRMAccountsWithEmbraceAccountStatus(IOrganizationService service, CRM_Embrace_IntegrationEntities3 db)
    {
        List<C_Tarsus_Account_Active_Seven__> crmAccountList = new List<C_Tarsus_Account_Active_Seven__>();
        //Here I get the list from Staging table
        var crmAccounts = db.C_Tarsus_Account_Active_Seven__.Select(x => x).ToList();
        foreach (var dbAccount in crmAccounts)
        {
            CRMDataObjectFour modelObject = new CRMDataObjectFour()
            {
                ID = dbAccount.ID,
                Account_No = dbAccount.Account_No,
                Account_Name = dbAccount.Account_Name,
                Account_Status = Int32.Parse(dbAccount.Account_Status.ToString()),
                Country = dbAccount.Country,
                Terms = dbAccount.Terms
            };
        }
        var officialDatabaseList = crmAccounts;
        //Here I query CRM to
        foreach (var crmAcc in officialDatabaseList)
        {
            QueryExpression qe = new QueryExpression();
            qe.EntityName = "account";
            qe.ColumnSet = new ColumnSet("accountnumber", "new_embraceaccountstatus");
            qe.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            qe.Criteria.AddCondition("accountnumber", ConditionOperator.NotIn, "List of acconts for example");
            EntityCollection response = service.RetrieveMultiple(qe);
            //Here I update the optionset value
            foreach (var acc in response.Entities)
            {
                if (acc.Attributes["accountnumber"].ToString() == crmAcc.Account_No)
                {
                    if (acc.Contains("new_embraceaccountstatus"))
                    {
                        continue;
                    }
                    else
                    {
                        acc.Attributes["new_embraceaccountstatus"] = new OptionSetValue(Int32.Parse(crmAcc.Account_Status.ToString()));
                    }
                    Batch(service, new UpdateRequest { Target = acc });
                }
            }
        }
        // Call ExecuteBatch to ensure that any batched requests, get executed.
        ExeucteBatch(service)
    }
