      public void Cycle()
        {
            var cboxes = host ? relayRow2.CheckBoxes : relayRow.CheckBoxes;
            cboxes = (from checkBox in cboxes.ToList()
                select new CheckBox { Checked = true}).ToArray();
        }
