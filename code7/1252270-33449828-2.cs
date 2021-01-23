    private void dataGridView1_DragDrop_1(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(string)))
        {
            string item = (string)e.Data.GetData(typeof(System.String));
            Point clientPoint = dgv.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo info = dgv.HitTest(clientPoint.X, clientPoint.Y);
            if (info.Type == DataGridViewHitTestType.Cell)
            {
                if(dgv.Columns[info.ColumnIndex].HeaderText == "phone_number")
                    dgv.Rows[info.RowIndex].Cells[info.ColumnIndex].Value = item;
            }
        }
    }
