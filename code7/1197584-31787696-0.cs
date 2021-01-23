    Server srv = new Server("instance_name")
    foreach(AvialbilityGroup grp in srv.AvailabilityGroups)
    {
      Console.WriteLine("Found group {0} on instance {1}", grp.Name, srv.InstanceName);
      Console.WriteLine("  Replicas:");
      foreach(AvailabilityReplica replica in grp.AvailabilityReplicas)
      {
        Console.WriteLine("  Replica Name: {0}, Cluster Name: {1}", replica.Name, repica.Parent.Parent.ClusterName)
      }
    }
