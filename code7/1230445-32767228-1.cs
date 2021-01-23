                TableRow nameRow = new TableRow();
                nameRow.Attributes["class"] = "columnInfo";
        // Add display names to table
        foreach (var nameList in dataPair.Value)
        {
            TableRow nameRow = new TableRow();
            nameRow.Attributes["class"] = "columnInfo";
            for (int i = 0; i < 3; i++)
            {
                TableCell nameCell = new TableCell();
                nameRow.Cells.Add(nameCell);
                Button b = new Button();
                b.Attributes["class"] = "docButton";
                b.Attributes.Add("DWdocid", nameList[3]);
                b.Text = nameList[i];
                b.Click += new EventHandler((s, ea) => test(s, ea, b.Attributes["DWdocid"]));
                nameCell.Controls.Add(b);
            }
            resultTable.Rows.Add(nameRow);
        }
