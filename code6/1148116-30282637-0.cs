        using System.Collections.Generic;
        class GameObjectComparer : IComparer<GameObject>
        {
            public int Compare(GameObject left, GameObject right)
            {
                return left.Name.CompareTo(right.Name);
            }
        }
        //sort array of Cube GameObjects
        Array.Sort(cb, new GameObjectComparer());
