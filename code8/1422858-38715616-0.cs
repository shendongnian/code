    protected void btnSave_Click(object sender, EventArgs e)
    {
        string selectedDays = String.Empty;
        int j = 0;
        var items = new Dictionary<int,string>();
        for (int i = 0; i < daySelect.Items.Count; i++)
            items.Add(i, daySelect.Items[i].Selected ? daySelect.Items[i].Text : "");
        for (int i = 0; i < items.Count; i++ )
        {
            string current = items.ElementAt(i).Value;
            if(String.IsNullOrEmpty(selectedDays))
            {
                j = items.ElementAt(i).Key;
                selectedDays = current;
                continue;
            }
            else if(current != "")
            {
                if((j + 1) == i)
                {
                    int lastComma = selectedDays.LastIndexOf(',');
                    int lastDash = selectedDays.LastIndexOf('-');
                    if ((selectedDays.Contains('-') && !selectedDays.Contains(',')) || lastDash > lastComma)
                    {
                        string day = selectedDays.Substring(selectedDays.LastIndexOf('-') + 1, 3);
                        selectedDays = selectedDays.Replace(day, current);
                    }
                    else
                        selectedDays += ("-" + current);
                    j = items.ElementAt(i).Key;
                }
                else
                {
                    selectedDays += "," + current;
                    j = items.ElementAt(i).Key;
                }
            }
        }
        string vistingDays = selectedDays + "<br />" + frmTime.SelectedValue.ToString() + "-" + ToTime.SelectedValue.ToString();
    }
