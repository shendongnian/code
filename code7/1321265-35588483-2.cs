    private void pBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if(pBox2.Image != null)
            {
                if (DoDragDrop(pBox2.Image, DragDropEffects.Move) == DragDropEffects.Move)
                {
                    pBox2.Image = null;
                }
            }
        }
