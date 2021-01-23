      public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
           
            PhotoViewModel photo= ((photoViewModel)mi.CommandParameter);
            photoModel.Remove(photo);
        }
