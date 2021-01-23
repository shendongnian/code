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
