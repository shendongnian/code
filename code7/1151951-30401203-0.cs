     if (dataCell.ColumnInfo.Name.ToLower() == "unitprice")
            {
                dataCell.ForeColor = System.Drawing.Color.Blue;
                dataCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            }
    else
    {
    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
    }
