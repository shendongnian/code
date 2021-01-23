		private void lvMembers_MouseClick(object sender, MouseEventArgs e)
		{
			for (int itemIndex = 0; itemIndex < lvMembers.Items.Count; itemIndex++)
			{
				ListViewItem item = lvMembers.Items[itemIndex];
				Rectangle itemRect = item.GetBounds(ItemBoundsPortion.Label);
				if (itemRect.Contains(e.Location))
				{
					item.Checked = !item.Checked;
					break;
				}
			}
		}
