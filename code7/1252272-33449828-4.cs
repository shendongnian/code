    private void dataGridView1_DragDrop_1(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(string)))
        {
            DataGridView dgv = sender as DataGridView;
            string item = (string)e.Data.GetData(typeof(System.String));
            // Conversion in coordinates relative to the data
            Point clientPoint = dgv.PointToClient(new Point(e.X, e.Y));
            // get the element under the drop coordinates
            DataGridView.HitTestInfo info = dgv.HitTest(clientPoint.X, clientPoint.Y);
            // If it is a cell....
            if (info.Type == DataGridViewHitTestType.Cell)
            {
                // and its column's header is the required one....
                if(dgv.Columns[info.ColumnIndex].HeaderText == "phone_number")
                    dgv.Rows[info.RowIndex].Cells[info.ColumnIndex].Value = item;
            }
        }
    }
