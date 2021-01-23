    switch (levels)
    {
        case 1:
            AddHeight(Color.Yellow);
            break;
        case 2:
            AddHeight(Color.Red);
            break;
        case 3:
            AddHeight(Color.Green);
            break;
        default:
            AddHeight(Color.Black);
            break;
    }
    public void AddHeight(Color color){
        Size level = Graphics.DrawText(text, textSize, position, color);
        if (level != new Size()) // ???
        { 
            position.Y += level.Height;
        }
    }
