    for (int i = 0; i < weaponsList.Count; i++)
    {
      Button newButton = new Button();
      newButton.Name = Convert.ToString(i);
      newButton.Content = weaponsList[i].WeaponName += weaponsList[i].MinDamage += weaponsList[i].MaxDamage += weaponsList[i].Cost;
      newButton.Visibility = Visibility.Visible;
      newButton.Width = 502+10*i;
      newButton.Height = 78+10*i;
    }
