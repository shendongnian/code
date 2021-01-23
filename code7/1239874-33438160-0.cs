	if (cell == null)
				{
					cell = new UITableViewCell(UITableViewCellStyle.Default, "identifier");
				}
				else
				{
					if(cell.ContentView!=null)
					{
					foreach (UIView subview in cell.ContentView)
						{
							if (subview.Tag == -1)
							{
								subview.RemoveFromSuperview();
							}
						}
					}
				}
