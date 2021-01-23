    if (Uid != 0)
    {
      killer.Owner.Inventory.Add(Uid, 0, 1);
      DeadPool.Kernel.SendWorldMessage(new DeadPool.Network.GamePackets.Message("Congratulations! " + killer.Name + " has killed " + Name + " and dropped! " + Database.ConquerItemInformation.BaseInformations[Uid].Name + "!", System.Drawing.Color.White, 2011), Program.Values);
      return;
    }
