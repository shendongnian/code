    public IEnumerator<Page> GetEnumerator()
    {
        for (uint i = 1; i < this.myLength; i++)
        {
            // start count at 1 to skip first page
            Page p;
            try
            {
                p = new Page(this, i);
            }
            catch (ArgumentOutOfRangeException)
            {
                yield break;
            }
            yield return p;
        }
    }
