    private void switch(Control target, Control parent1, Control parent2)
    {
        if (target.Parent == parent1)
        {
            Point op = target.PointToScreen(Point.Empty);
            target.Parent = parent2;
            target.Location = parent2.PointToClient(op);
        }
        else
        {
            Point op = target.PointToScreen(Point.Empty);
            target.Parent = parent1;
            target.Location = parent1.PointToClient(op);
        }
    }
