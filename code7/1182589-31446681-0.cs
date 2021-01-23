    private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {                
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {                                       
                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(dataGridView1.Rows[rowIndexFromMouseDown], DragDropEffects.Copy);
                }
            }
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {                             
                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else               
                dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
                {
                    Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));                   
                    if (e.Effect == DragDropEffects.Copy)
                    {
                        DataGridViewRow Row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                        dataGridView1.Rows.Add(Row.Cells[0].Value, Row.Cells[1].Value, Row.Cells[2].Value);
                    }
                }
                else
                {
                    //Reflect the exception to screen
                    MessageBox.Show("Geen data! #01", "Error");
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message, "Error");
            }
        }
