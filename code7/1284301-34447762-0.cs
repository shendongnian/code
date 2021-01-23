    if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                        {
                            //Get the target property and check whether its a contact.
                            Entity target = (Entity)context.InputParameters["Target"];
    
                            string primaryContactId = target.Attributes.Contains("primarycontactid") ? ((EntityReference)target.Attributes["primarycontactid"]).Name : string.Empty;
                            string accountName = target.Attributes.Contains("name") ? target.Attributes["name"].ToString() : string.Empty;
                            target["name"] = accountName + "-" + primaryContactId;
    
                        }
