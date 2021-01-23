    public class SelectListItemComparer : IEqualityComparer<SelectListItem>
        {
            public bool Equals(SelectListItem x, SelectListItem y)
            {
                return x.Text == y.Text && x.Value == y.Value;
            }
    
            public int GetHashCode(SelectListItem  item)
            {
                int hashText = item.Text == null ? 0 : item.Text.GetHashCode();
                int hashValue = item.Value == null ? 0 : item.Value.GetHashCode();
                return hashText ^ hashValue;
            }
        }
