    if (e.PropertyType == typeof(System.Char))
            {
                DataGridCheckBoxColumn col = new DataGridCheckBoxColumn();
                col.Header = e.Column.Header;
                Binding binding = new Binding(e.PropertyName);
                binding.Converter = new CharToBooleanConverter();
                col.Binding = binding;
                e.Column = col;
            }
