        private void ProcessComboBoxes(ComboBox senderBox)
        {
            ComboBox dependentBox = lookupDependent[senderBox];
            var itemType = itemTypes[senderBox.selectedIndex];
            var listOfItemsNeeded = lookupItemsByType[itemType];
            dependentBox.Items.Clear();
            foreach (string item in listOfItemsNeeded){
                dependentBox.Items.Add(item);
            }
            dependentBox.IsEnabled = true;
        }
