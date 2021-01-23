    public static void OrganiseSquares(List<Square> pio_Squares)
    {
        double xPosition = 0;
        double spacing = 15;
        foreach (var square in pio_Squares.OrderBy(sq=>sq.GetLenght())
        {
            square.SetPosition(xPosition, 0);
            xPosition += square.GetLenght() + spacing
        }
    }
