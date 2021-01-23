    public static IEnumerable<Comment> Sort(List<Comment> SortItemsList, int parentID = 0)
    {
        foreach (var item in SortItemsList.Where(x => x.comment_parent_id == parentID).OrderBy(x => x.comment_id).ToList())
        {
            yield return item;
            foreach (var child in Sort(SortItemsList, item.comment_id))
            {
                yield return child;
            }
        }
    }
