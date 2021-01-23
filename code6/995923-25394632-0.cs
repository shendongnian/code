        settings.Columns.Add(column =>
        {
            var commmonHeaderStyle = column.HeaderStyle as GridViewHeaderStyle;
            commmonHeaderStyle.Font.Bold = true;
            column.CellStyle.Wrap = DefaultBoolean.True;
            column.FieldName = "Test";
            column.Width = System.Web.UI.WebControls.Unit.Percentage(30);
        });
