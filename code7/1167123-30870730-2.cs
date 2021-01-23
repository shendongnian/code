    public T CheckCollisionAgainst<T>() where T : class, Obj
    {      
        // If collision detected, returns the colliding object; otherwise null.
        return Items.objList
            .OfType<T>()
            .FirstOrDefault(o.area.Intersects(area));
    }
--------------
    Enemy enemy = CheckCollisionAgainst<Enemy>();
    if (enemy != null)
    {
        alive = false;
    }
