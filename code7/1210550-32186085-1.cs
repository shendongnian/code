    private void View_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (View.SelectedItems.Count > 0)
        {
            //new code tryout
            //When I try to do it like this Code runs fine but no image is displayed on picturebox
            object O = Resources.ResourceManager.GetObject(View.SelectedItems[0].Text);
    
            PicBox.Image = (Image)O;
        }
    }
