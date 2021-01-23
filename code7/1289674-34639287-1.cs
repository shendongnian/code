    for (int i = 0; i < 60; i++)
            {
                if (i == team.PlayTime.Minutes)
                {
                    listBoxobjM.SelectedIndex = i;
                    await Task.Delay(1000);
                    listBoxobjM.ScrollIntoView(listBoxobjM.SelectedItem);
                }
                if (i == team.PlayTime.Seconds)
                {
                    listBoxobjS.SelectedIndex = i;
                    await Task.Delay(1000);
                    listBoxobjS.ScrollIntoView(listBoxobjS.SelectedItem);
                }
            }
 
