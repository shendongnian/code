    private void propertyGridNewBonus_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
            {
                switch (e.ChangedItem.Label)
                {
                    case "somePropertyLabel":
                        newBonus.somePropertyValue = e.OldValue.ToString();
                        break;
                    default:
                        break;
                }
            }
