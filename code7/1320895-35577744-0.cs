     if (e.DataColumn.FieldName == "BusType")
        {
            if (e.GetValue("BusType").ToString() == "CUS")
            {
                e.Cell.BackColor = System.Drawing.Color.LightCyan;
                e.Cell.ForeColor = System.Drawing.Color.DarkRed;
                // and so on...
            }
        }
