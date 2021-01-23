    public CustomObject Find(List<CustomObject> list, CustomObject cfo)
    {
        return list.Find(item => IsWithinBoxOf(cfo, item));
    }
    private bool IsWithinBoxOf(CustomObject cfo, CustomObject item)
    {
        // return whether the item is within the box of cfo.
        return item.X <= cfo.X + 1 && item.Y <= cfo.Y + 1;
    }
