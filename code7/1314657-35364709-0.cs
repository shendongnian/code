    public Vector Momentum
    {
        get{
             return new Vector(Velocity.x*mass, Velocity.y*mass);
        }
    }
