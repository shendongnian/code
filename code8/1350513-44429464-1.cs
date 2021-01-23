    StringBuilder sb = new StringBuilder();
          using (Html.Table table = new Html.Table(sb, id: "some-id"))
          {
            table.StartHead();
            using (var thead = table.AddRow())
            {
              thead.AddCell("Category Description");
              thead.AddCell("Item Description");
              thead.AddCell("Due Date");
              thead.AddCell("Amount Budgeted");
              thead.AddCell("Amount Remaining");
            }
            table.EndHead();
            table.StartBody();
            foreach (var alert in alertsForUser)
            {
              using (var tr = table.AddRow(classAttributes: "someattributes"))
              {
               tr.AddCell(alert.ExtendedInfo.CategoryDescription);
                tr.AddCell(alert.ExtendedInfo.ItemDescription);
                tr.AddCell(alert.ExtendedInfo.DueDate.ToShortDateString());
                tr.AddCell(alert.ExtendedInfo.AmountBudgeted.ToString("C"));
                tr.AddCell(alert.ExtendedInfo.ItemRemaining.ToString("C"));
              }
            }
            table.EndBody();
          }
          return sb.ToString();
