    protected void GenGridView()
        {
            var data = project.ObtainDataDescJSON();
            Title = "show";
            for (int rowCtr = 0; row < data.Num.Count; row++)
            {
                var buttonField = new ButtonField
                {
                    ButtonType = ButtonType.Button,
                    Text = "Show",
                    CommandName = "Display"
    
                };
    
                buttonField.Attributes.Add("data-toggle", "modal");
                buttonField.Attributes.Add("data-target", "#myModal");
                buttonField.CssClass = "btn btn-info";             
    
                ModelNumFieldsGrid.Columns.Add(buttonField);
                break;
            }
          }
