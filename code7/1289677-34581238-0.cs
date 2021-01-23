    public void DrawPeg(int x, int numberOfRings = 0)
    {
            for (int i = pegheight; i >= 1; i--)
            {
                string halfRing = new string(' ', i);
                if (numberOfRings > 0)
                {
                    if (i <= numberOfRings)
                        halfRing = new string('-', numberOfRings - i + 1);
                }
                Console.SetCursorPosition(x - halfRing.Length * 2 + i + (halfRing.Contains("-") ? (-i + halfRing.Length) : 0), y);
                Console.WriteLine(halfRing + "|" + halfRing);
                y++;
            }
            if (x < 7)
            {
                x = 7;
            }
            Console.SetCursorPosition(x - 7, y); // print the base
            Console.WriteLine("----------------");
    }
