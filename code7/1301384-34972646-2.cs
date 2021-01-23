    private void cbSelectCluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        XElement root = XElement.Load("filename.xml");
        if (!cbSelectCluster.Text.Trim().Equals(""))
        {
            cbSelectMachineID.Enabled = true;
            var machineIds = root
                .Elements("Machines")
                .Elements("Cluster")
                .Where(clusterElement => (string)clusterElement.Element("ClusterName") == cbSelectCluster.Text)
                .Elements("MachineID")
                .Select(x => (string)x)
                .ToList();
            BindingSource bs = new BindingSource();
            bs.DataSource = machineIds;
            cbSelectMachineID.DataSource = bs;
        }
    }
				
