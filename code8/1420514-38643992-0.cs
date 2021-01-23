            if (e.Row.Index == 0)
            {
                foreach (GridRecordItem gri in e.Row.Items)
                {
                    BoundDataField field = gri.Column as BoundDataField;
                    if (field.Key == "InsertedOnCC")
                        field.DataFormatString = "{0:g}";
                }
            }
