    public override bool Equals ( object obj )
    {
       return Equals(obj as Point);
    }
    
    public bool Equals ( Point obj )
    {
       return obj != null && obj.X == this.X && obj.Y == this.Y && obj.Z == this.Z; 
    }
