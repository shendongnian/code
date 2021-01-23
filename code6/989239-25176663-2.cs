    private void ClickButton(Button button)
    {
        if (button.Visible)
        {
            button.PerformClick();
            return;
        }
        var size = button.Size;
        button.Size = Size.Empty;
        button.Show();
        button.PerformClick();
        button.Hide();
        button.Size = size;
    }
     
