    void cboCities_SelectedIndexChanged(object sender, EventArgs e)
    {
         if(cboCities.SelectedItem != null)
         {
             string txt = cboCities.SelectedItem.ToString();
             if(poi.ContainsKey(txt))
             {
                  List<string>points = poi[txt];
                  cboPointsOfInterest.Items.Clear();
                  cboPointsOfInterest.Text = string.Empty;
                  cboPointsOfInterest.Items.AddRange(points.ToArray());
             }
        }
    }
