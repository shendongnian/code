    public class MenuItem : IEntityBase
    {
        //Rest of your code goes here
        public IEnumerable<MenuItem> GetDescendants(bool includeItself = true)
        {
            if (includeItself)
            {
                yield return this;
            }
            foreach (MenuItem menuItem in this.Children)
            {
                foreach (MenuItem descendant in menuItem.GetDescendants(includeItself: true))
                {
                    yield return descendant;
                }
            }
        }
    }
