            ComboboxItem item = new ComboboxItem();
            for (int i = 0; i < list[0].Count(); i++)
            {
                item.Value = list[0][i];
                item.Text = (list[1][i] + " - " + list[0][i]);
                CbBGroup.Items.Add(item);
            }
