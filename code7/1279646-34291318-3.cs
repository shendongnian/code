    void cboCities_SelectedIndexChanged(object sender, EventArgs e)
    {
         string txt = cboCities.Text;
         if(poi.ContainsKey(txt))
         {
              List<string>points = poi[txt];
              cboPointsOfInterest.Items.Clear();
              cboPointsOfInterest.Items.AddRange(points.ToArray());
         }
    }
