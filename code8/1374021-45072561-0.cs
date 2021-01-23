    public void RightHandRulePlane()
    {
        var plane = System.Numerics.Plane.CreateFromVertices
            (
             new System.Numerics.Vector3( 0, 0.5f, 0 )
             , new System.Numerics.Vector3( 1, 0.5f, 0 )
             , new System.Numerics.Vector3( 0, 0.5f, 1 ) );
        Console.WriteLine( plane.ToString() );
        plane = System.Numerics.Plane.CreateFromVertices
            (
              new System.Numerics.Vector3( 0, 0.5f, 1 )
             , new System.Numerics.Vector3( 1, 0.5f, 0 )
             , new System.Numerics.Vector3( 0, 0.5f, 0 )
             );
        Console.WriteLine( plane.ToString() );
    }
