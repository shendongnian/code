    public void updatePosition()
        {
            Grid.SetRow(this, (int)position.Y);
            Grid.SetColumn(this, (int)position.X);
            Margin = new Thickness();
        }
