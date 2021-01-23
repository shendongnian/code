    //I'm assuming TileA,etc. is of type Sprite.  If I'm wrong, you can adjust accordingly.
    //Pre-create this array (outside of your loops)
    Sprite [] spriteArray = new Sprite[]{ TileA, TileB . . . etc. };
     
     
    //Now your inner loop can look something like this.
    foreach(Transform child in element.transform) 
    {
        var childSprite = child.GetComponent<SpriteRenderer>().sprite;
        if (Array.BinarySearch(spriteArray, childSprite) >= 0) {
            //item is in the array
            Destroy(child.GetComponent < PolygonCollider2D > ());
        }
        else
        {
            //item not in the array
            child.gameObject.AddComponent < PolygonCollider2D > ();
        }
    }
    //Please treat above as helpful pseudo-code, but not a full implementation, as I'm not that familiar with Unity.
