    private void RefreshWindowsList()
        {
            //Graphics g; <- You dont need this         
            //g = GraphicsfromImage(img); <- You dont need this
            //g.Clear(Color.White); <- You dont need this
            //ClearGraphics = true; <- You dont need this
            this.listBoxSnap.Items.Clear();
            buttonSnap.Enabled = false;
            this.listBoxSnap.Items.AddRange(WindowSnap.GetAllWindows(true, true).ToArray());
            buttonSnap.Enabled = true;
            for (int i = listBoxSnap.Items.Count - 1; i >= 0; i--)
            {
                string tt = listBoxSnap.Items[i].ToString();
                if (tt.Contains(" ,"))
                {
                    listBoxSnap.Items.RemoveAt(i);
                }
            }
            rectangles = new Rectangle[listBoxSnap.Items.Count];
            isCropped = new bool[listBoxSnap.Items.Count];
            //ConfirmRectangle.Enabled = false; <- You dont need this
            textBoxIndex.Text = listBoxSnap.Items.Count.ToString();
            if (this.listBoxSnap.Items.Count > 0)
                this.listBoxSnap.SetSelected(0, true);
            listBoxSnap.Select();
            //pictureBoxSnap.Invalidate(); <- You dont need this
        }
