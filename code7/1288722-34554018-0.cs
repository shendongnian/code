    settings.Columns.Add(column => {
                column.FieldName = "Unbound";
                column.Caption = "Button";
                column.UnboundType = DevExpress.Data.UnboundColumnType.String;
                column.EditFormSettings.Visible = DevExpress.Utils.DefaultBoolean.False;
                column.Width = Unit.Percentage(10);
                column.SetDataItemTemplateContent((c) => {
                    htmlHelper.DevExpress().Button(b => {
                        b.Name = "Button" + c.KeyValue;
                        b.Text = "Test";
                        b.ClientSideEvents.Click = string.Format(@"function(s, e) {{ alert({0}); }}", c.KeyValue);
                    }).GetHtml();
                });
            });
