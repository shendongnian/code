    if(_currentKeyboardState.IsKeyDown(Keys.Space) && _previousKeyboardState.IsKeyUp(Keys.Space))
    {
        using (var dialog = new System.Windows.Forms.OpenFileDialog())
        {
            dialog.Filter = "PNG (*.png)|*.png";
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileName = System.IO.Path.GetFileName(dialog.FileName);
                System.IO.File.Copy(dialog.FileName, System.IO.Path.Combine("Content", fileName));
                _texture = this.Content.Load<Texture2D>(fileName);
            }
        }
    }
