    for (int i = 0; i < checkedMonthsBox.Items.Count; i++)
            {
                if (checkedMonthsBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    months.Add(checkedMonthsBox.Items[i].ToString());
                }
             }
