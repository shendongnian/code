        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridGroupHeaderItem)
        {
            GridGroupHeaderItem headerItem = e.Item as GridGroupHeaderItem;
            int index = headerItem.GroupIndex.Split('_').Length - 1;
            GridGroupByExpression exp = headerItem.OwnerTableView.GroupByExpressions[index] as GridGroupByExpression;
            string fieldName = exp.GroupByFields[0].FieldName;
            if (fieldName == "ShipName")
            {
                Button button = new Button()
                {
                    ID = "GroupButton1",
                    Text = "MyButton"
                };
                headerItem.Load += (s, a) =>
                {
                    headerItem.DataCell.Controls.Add(new Literal() { Text = headerItem.DataCell.Text });
                    headerItem.DataCell.Controls.Add(button);
                };
            }
        }
    }
