       var commandgroup = new Command[]
            {
                    AR303000Schema.CustomerSummary.ServiceCommands.EveryCustomerID
                ,   WSTools.NewA4Field(AR303000Schema.CustomerSummary.CustomerID.ObjectName, "DefContactID") 
                , AR303000Schema.CustomerSummary.CustomerID 
                , AR303000Schema.CustomerSummary.CustomerName 
                ,   WSTools.NewA4Field(AR303000Schema.CustomerSummary.CustomerID.ObjectName, "BAccountID") 
                ,   WSTools.NewA4Field(AR303000Schema.CustomerSummary.CustomerID.ObjectName, "Type") 
                ,AR303000Schema.CustomerSummary.Status 
                , AR303000Schema.GeneralInfoMainContact.Phone1  
                , AR303000Schema.GeneralInfoMainContact.Phone2
                ,   WSTools.NewA4Field(AR303000Schema.GeneralInfoMainContact.Phone1.ObjectName, "Phone1Type") 
                ,   WSTools.NewA4Field(AR303000Schema.GeneralInfoMainContact.Phone1.ObjectName, "Phone2Type") 
                WSTools.NewA4Field(AR303000Schema.CustomerSummary.CustomerID.ObjectName, "LastModifiedDateTime") 
               
            };
