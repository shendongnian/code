    var hiddenRows = ultraGrid1.Rows.Where(r => r.IsFilteredOut);
                foreach (var hiddenRow in hiddenRows)
                {
                    var item = e.ValueList.ValueListItems.Cast<ValueListItem>().
                        FirstOrDefault(i => i.DisplayText == hiddenRow.Cells[e.Column].Text);
                    if (item != null)
                    {
                        e.ValueList.ValueListItems.Remove(item);
                    }
                }
