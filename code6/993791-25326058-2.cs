    public void load_tableData(DataTable table)
        {
            BindingSource binding = new BindingSource();
            binding.DataSource = table;
            dataGridView.DataSource = binding;
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
