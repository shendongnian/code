    foreach(Clue g in markedObjects){ <-- get each Clue in markedObjects
        print (g);
        if (!markedObjects.Contains(c)){ <-- if c is not within all of markedObjects then destroy c? Perhaps you meant to destroy g.
            Debug.Log("Destroy");
            Destroy (c.getSprite()); 
        }
    }
}
