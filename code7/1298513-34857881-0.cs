    private void DisplayVehiclesForTreeView(List<VehicleEntry> vehicles)
    {
        // Loop through each vehicle
        foreach (VehicleEntry vehicle in vehicles)
        {
            // Make node by VehicleEntry
            TreeNode vehNode = new TreeNode("VehicleEntry");
            foreach (PropertyInfo propertyInfo in vehicle.GetType().GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    object val = propertyInfo.GetValue(vehicle, null);
                    if (val is string)
                    {
                        vehNode.Nodes.Add(new TreeNode(propertyInfo.Name + ": " + val));
                    }
                    else if (val is BsonDocument)
                    {
                        vehNode.Nodes.Add(GetNodeForDocument((BsonDocument)val, propertyInfo.Name));
                    }
                }
            }
            // Add node to tree view
            treeView1.Nodes.Add(vehNode);
        }
    }
