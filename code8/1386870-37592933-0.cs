    // . . .
    
    previousCollisions = currentCollisions; // Ready for the next frame
    currentCollisions = new List<Entity>(); // Now both lists are not clear
    base.Update(gameTime);
