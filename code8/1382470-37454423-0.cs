        private void DataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                DataGridViewCell clicked = dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
                if (typeof(YourDesiredControlType).IsAssignableFrom(clicked.ValueType))
                {
                    dataGridView1.CurrentCell = clicked;
                    dataGridView1.BeginEdit(false);
                }
                else
                    dataGridView1.EndEdit();
            }
        }
