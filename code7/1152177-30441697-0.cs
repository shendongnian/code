        for (int index = 0; index < panel_Schedule.Controls.Count / 2; index++)
            {
                CheckBox currentCheck = panel_Schedule.Controls.OfType<CheckBox>().ElementAt<CheckBox>(index);
                if (currentCheck.Checked)
                {
                    panel_Schedule.Controls.OfType<NumericUpDown>().ElementAt<NumericUpDown>(index).Visible = true;
                    nbScheduleModesChecked++;
                }
                else
                {
                    panel_Schedule.Controls.OfType<NumericUpDown>().ElementAt<NumericUpDown>(index).Visible = false;
                }
            }
