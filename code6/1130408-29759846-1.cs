    public static bool InsertEnemy(Enemy[] enemies, Enemy newEnemy)
    {
        // binary search in O(logN)
        var ix = Array.BinarySearch(enemies, newEnemy, new EnemyComparer());
        // If not found, the bit-wise compliment is the insertion index
        if (ix < 0)
            ix = ~ix;
        // If the insertion index is after the list we bail out...
        if (ix >= enemies.Length)
            return false;// Insert is after last item...
        //Move enemies down the list to make room for the insertion...
        if (ix + 1 < enemies.Length)
            Array.ConstrainedCopy(enemies, ix, enemies, ix + 1, enemies.Length - (ix + 1));
        //Now insert the newEnemy into the position
        enemies[ix] = newEnemy;
        return true;
    }
