           static int syc = 0;
        public static void RemoveFirewallRules(string RuleName, int Ruleslocaitonid)
        {
            try
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
                var currentProfiles = fwPolicy2.CurrentProfileTypes;
                #region RulesRemove
                foreach (INetFwRule rule in fwPolicy2.Rules)
                {
                    if (rule.Name.IndexOf(RuleName) != -1)
                    {
                        if (syc == Ruleslocaitonid)
                        {
                            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                            firewallPolicy.Rules.Remove(rule.Name);
                            MessageBox.Show(rule.Name + " Güvenlik duvarı kural silindi.");
                            syc = 0;
                            break;
                        }
                        else
                        {
                            syc++;
                        }
                    }
                    else
                    {
                        syc++;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "BekraHayrNester");
            }
        }
    
