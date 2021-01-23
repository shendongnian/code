    int TotalPoints()
    {
            int total = (from i in GetControlsWithPoint(this)
                         where i.Text != null && i.Text != string.Empty
                         select Convert.ToInt32(i.Text)).Sum();
           // MessageBox.Show("total" + total);
            return total;
    }
    List<Control> GetControlsWithPoint(Control parent)
    {
            List<Control> results = new List<Control>();
            if (parent == null)
                return results;
            foreach (Control item in parent.Controls)
            {
                if (item.Name == "labelChkBoxPoints" || item.Name == "labelTxtBoxPoints")
                    results.Add(item);
                results.AddRange(GetControlsWithPoint(item));
            }
            return results;
     }
