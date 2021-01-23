    public class PriceList
{
    public string Agreement { get; set; }
    public Currency Currency { get; set; }
    public string Description { get; set; }
    public Nullable<DateTime> EndDate { get; set; }
    public int Id { get; set; }
    public Nullable<Guid> ImageKey { get; set; }
    public bool IsBid { get; set; }
    public bool IsLimitedToStock { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsPublic { get; set; }
    public string Name { get; set; }
    public Nullable<DateTime> StartDate { get; set; }
    public int Type { get; set; }
