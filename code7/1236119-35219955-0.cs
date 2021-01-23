    if (Request["Selected"] != null)
                {
                    model.msisdn = string.Empty;
                    model.MessageId = string.Empty;
                    foreach (var selection in Request["Selected"].Split(','))
                    {
                       
                    }
                }
