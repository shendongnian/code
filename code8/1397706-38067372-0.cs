    public interface IPage<TItem>
    {
        int Count { get; set; }
        List<TItem> PageItems { get; set; }
    }
