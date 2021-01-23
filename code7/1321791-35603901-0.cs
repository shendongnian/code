        foreach (DataGridViewRow row in datagridview.SelectedRows)
        {
            var Id = row.Cells["typeID"].Value.ToString();
            int typeID;
            if (!String.IsNullOrWhiteSpace(Id) && int.TryParse(Id, out PlayerID))
            {
                Label label1 = new Label();
                label1.Text = row.Cells["PlayerType"].Value.ToString();
              //Does not matter for type of player
              //flpGoalie.Controls.Add(label1);
			Control[] ctrls = Controls.Find("flp" + label1.Text, true);
			if (ctrls != null && ctrls.Length > 0){
			    FlowLayoutPanel flp = ctrls[0] as FlowLayoutPanel;
                flp.Controls.Add(label1);
              }
       }
