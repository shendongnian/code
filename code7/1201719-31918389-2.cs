    foreach (var itemCheckBox in checklistbox)
    {
         foreach (var itemOnlineVault in onlineVaults)
         {
             if (string.Compare(itemOnlineVault.Trim(), itemCheckBox.Trim(), StringComparison.InvariantCultureIgnoreCase) == 0)
             {
                  checkedListBox.SetItemChecked(index, true);
                  index++;
                  break;
             }
             checkedListBox.SetItemChecked(index, false);
             index++;
         }
    }
