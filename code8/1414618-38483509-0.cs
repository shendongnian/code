      using (new EditContext(item))
                {
                    MultilistField mlField = new MultilistField(item.Fields["Multilist"]);
                    mlField.Add(redColorItem.ID.ToString());
                    mlField.Add(blueColorItem.ID.ToString());
                    mlField.Add(greenColorItem.ID.ToString());
                }
