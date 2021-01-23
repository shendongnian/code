    public static Vector3 RealWorldSpaceToOtherSpace(Vector3 realspace, Vector4 clipplane)
    {
        // Work out the normal vectors of 3 imaginary planes
        Vector3 floor = new Vector3(clipplane.X, clipplane.Y, clipplane.Z);
        Vector3 centre = new Vector3(1f, -clipplane.X / clipplane.Y, 0f);
        Vector3 wall = Vector3.Cross(floor, centre);
        // Get distances from the planes
        // Distance is represented as a Vector, since it needs to hold
        // the direction in 3d space.
        Vector3 distanceToFloor = new Vector3(0f,   realspace.y ,0f,);
        Vector3 distanceToCentre = new Vector3(     realspace.x ,0f,0f,);
        Vector3 distanceToWall = new Vector3(0f,0f, realspace.z );
        // Create planes that contain all the possible positions of the point
        // based on the distance from point to the corresponding plane.
        Vector3 pointY = floor + distanceToFloor;
        Vector3 pointX = centre + distanceToCentre;
        Vector3 pointZ = wall + distanceToWall;
        // Now that we have all 3 point's dimensions, we can create a new vector that will hold its position.
        Vector3 point = new Vector3(pointX.x,pointY.y, pointZ.z);
        return point
    }
