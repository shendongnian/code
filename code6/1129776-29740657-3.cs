            foreach (ComboBox box in _boxList)
			{
				ComboBox.ObjectCollection _items = box.Items;
				foreach (var item in _items)
				{
					_itemsList.Add(item);
				}
			}
