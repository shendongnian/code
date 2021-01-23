public static void Bekragetroles(DataGridView dataGridView1)
{
    try
    {
        dataGridView1.Rows.Clear();
        Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        dynamic fwPolicy2 = Activator.CreateInstance(tNetFwPolicy2) as dynamic;
        IEnumerable Rules = fwPolicy2.Rules as IEnumerable;
        foreach (dynamic rule in Rules)
        {
            dataGridView1.Rows.Add(
               rule.name,
               rule.ApplicationName,
               rule.Description,
               rule.Direction,
               rule.EdgeTraversal,
               rule.EdgeTraversalOptions,
               rule.Enabled,
               rule.Grouping,
               rule.IcmpTypesAndCodes,
               rule.Interfaces,
               rule.InterfaceTypes,
               rule.LocalAddresses,
               rule.LocalAppPackageId,
               rule.LocalPorts,
               rule.LocalUserAuthorizedList,
               rule.LocalUserOwner,
               rule.Profiles,
               rule.Protocol,
               rule.RemoteAddresses,
               rule.RemoteMachineAuthorizedList,
               rule.RemotePorts,
               rule.RemoteUserAuthorizedList,
               rule.SecureFlags,
               rule.serviceName,
               rule.Action
                );
            dataGridView1.PerformLayout();
        }
        MessageBox.Show("All Rules listed.");
    }
    catch (Exception ex)
    { MessageBox.Show(ex.Message, "BekraHayrNester"); }
}
Example Form Code:
SyhMhfz.Bekragetroles(dataGridView1);
Rules Delete Method Code:
]
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
Form Example:
SyhMhfz.RemoveFirewallRules(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Index);
This code is currently running, you can see:
![enter image description here][1]
  [1]: https://i.stack.imgur.com/9En6C.png
