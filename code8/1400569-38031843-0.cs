     Vector3 facingDirection = new Vector3(RotMatrix[2, 0], RotMatrix[2, 1], RotMatrix[2, 2]); // direction vector
                        Vector3 currentPos = new Vector3(character.PosX, character.PosY, character.PosZ); // I also have position of the character
    // Now calculate a point 10000 units away along the vector line 
                        var px = currentPos.X + facingDirection.X * 10000;
                        var py = currentPos.Y + facingDirection.Y * 10000;
                        var pz = currentPos.Z + facingDirection.Z * 10000;
                        return new Vector3(px, py, pz);
