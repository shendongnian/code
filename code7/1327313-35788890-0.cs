     protected void PositionShift_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (PositionShift.SelectedIndex == 1 || PositionShift.SelectedIndex == 3 || PositionShift.SelectedIndex == 5)
                {
                    RequisitionNumberLabel.Text = "*";
                }
                else
                {
                    RequisitionNumberLabel.Text = "Requisition Number";
                }
            }
