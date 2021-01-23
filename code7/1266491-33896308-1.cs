                    Int32 statusVal = 2;
                    Int32 stateVal = 0;
                    if (((Entity)context.InputParameters["Target"]).Contains("statuscode"))
                    {
                        ((Entity)context.InputParameters["Target"])["statuscode"] = new OptionSetValue(statusVal);
                    }
                    else {
                        ((Entity)context.InputParameters["Target"]).Attributes.Add("statuscode", new OptionSetValue(statusVal));
                    }
                    if (((Entity)context.InputParameters["Target"]).Contains("statecode"))
                    {
                        ((Entity)context.InputParameters["Target"])["statecode"] = new OptionSetValue(stateVal);
                    }
                    else
                    {
                        ((Entity)context.InputParameters["Target"]).Attributes.Add("statecode", new OptionSetValue(stateVal));
                    }
