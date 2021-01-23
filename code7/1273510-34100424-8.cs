    Client.Player.PropertyChanged += (sender, pcEventArgs) =>
    {
        var player= (Player)sender;
        if(pcEventArgs.PropertyName == nameof(player.Level))
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            { 
                if (player.Inventory[i] == null)
                {
                    player.Inventory[i] = player.Manager.GameData.Items[0x7016];
                    player.UpdateCount++;
                    player.SaveToCharacter();
                    player.SendInfo("You've been given 10 gold for leveling up!");
                }
            }
        }
    }
