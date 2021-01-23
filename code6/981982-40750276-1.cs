    private int ItemMatches(string text)
    {
            bool matches = false;
            int idx      = -1;
            for (int i   = chemicalSearchIndex; i < listViewChemical.Items.Count; i++)
            {
                ListViewItem item = listViewChemical.Items[i];
                matches          |= item.Text.ToLower().Contains(text.ToLower());
                if (matches)
                {
                    idx = item.Index;
                    break;
                }
                if (!checkBoxFormulaOnly.Checked)
                {
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    {
                        matches |= subitem.Text.ToLower().Contains(text.ToLower());
                        if (matches)
                        {
                            idx = item.Index;
                            break;
                        }
                    }
                }
            }
            if (idx >= 0)
            {
                listViewChemical.Items[idx].EnsureVisible();
                listViewChemical.Items[idx].Selected = true;
                listViewChemical.Select();
                chemicalSearchIndex      = idx + 1;
                if (chemicalSearchIndex >= listViewChemical.Items.Count)
                {
                    chemicalSearchIndex  = 0;  //go back to top
                }
            }
            else
            {
                //No matches
                chemicalSearchIndex = 0;  //set next find or next to start at the beginning of the list
            }
            return idx;
        }
