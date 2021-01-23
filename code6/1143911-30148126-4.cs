    //I'm assuming TileA,etc. is of type Sprite.  If I'm wrong, you can adjust accordingly.
    //Pre-create this array (outside of your loops)
    Sprite [] spriteArray = new Sprite[]{ TileA, TileB . . . etc. };
    
    //an example SpriteComparer class you will need
    public class SpriteComparer : IComparer<Sprite>
    {
        public int Compare(Sprite A, Sprite B) {
            if (A.Equals(B)) {
                return 0;
            } else {
                return -1;
            }
        }
    }
    //create one of these outside of your loops
    SpriteComparer comparer = new SpriteComparer();
     
    //Now your inner loop can look something like this.
    foreach(Transform child in element.transform) 
    {
        var childSprite = child.GetComponent<SpriteRenderer>().sprite;
        if (Array.BinarySearch(spriteArray, childSprite,comparer) >= 0) {
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
