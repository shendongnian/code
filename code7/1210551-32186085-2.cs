    private void View_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (View.SelectedItems.Count > 0)
        {
            object O = Resources.ResourceManager.GetObject(View.SelectedItems[0].Text);
    
            PicBox.Image = (Image)O;
        }
    }
