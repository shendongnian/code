    {
            if (!database.IsMaster)
            {
                DataGridTextColumn dgtc = new DataGridTextColumn();
                dgtc.Header = database.DisplayName;
                dgtc.Binding = new Binding("LocationValues[" + counter + "]");
                                
                Converter converter = new Converter();
                Binding binding = new Binding(DeltaValues[i]);
                binding.Converter = converter;
                
                dgtc.CellStyle.Setters.Add(new Setter(Control.BackgroundProperty, binding));
                dataGrid.Columns.Add(dgtc);
                counter++;
            }
            return this;
        }
