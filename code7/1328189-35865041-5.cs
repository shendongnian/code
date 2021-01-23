    private void GrdWorkingCompany_RowDataBound(object sender, Obout.Grid.GridRowEventArgs e)
        {
            foreach (Obout.Grid.Column column in GrdWorkingCompany.Columns)
            {
                if (!string.IsNullOrEmpty(column.TemplateId))
                {
                    var cell = e.Row.Cells[column.Index] as Obout.Grid.GridDataControlFieldCell;
                    var checkBoxControls = cell.FindControlsByType(typeof(HtmlInputCheckBox));
                    if (checkBoxControls.Count > 0)
                    {
                        var checkbox = checkBoxControls[0] as HtmlInputCheckBox;
                        checkbox.Attributes.Add("disabled", "true");
                    }
                }
            }
        }
