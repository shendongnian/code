    for (int i = 0; i < objects.Count; i++) 
    {
        SimulationObject obj = null;
        try 
        {
            obj = objects[i];
        }
        catch (ArgumentOutOfRangeException) 
        {
            // something was removed from the collection
            // we reached the end of the list
            break;
        }
        obj.Update(deltaTime)
    }
