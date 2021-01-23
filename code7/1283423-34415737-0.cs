     void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.Column.Name == "column2" && e.Row.Cells["someColumn"].Value == something)
            {
                e.CellElement.Text = "some text";
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.TextProperty, ValueResetFlags.Local);
            }
        }
