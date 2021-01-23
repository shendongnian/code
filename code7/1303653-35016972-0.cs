    public class Unit
    {
    public int UnitID { get; set; }
    ...
    public Nullable<int> PreviousUnitID { get; set; }
    [ForeignKey("PreviousUnitID")]
    public virtual Unit PreviousUnit { get; set; }
    public Nullable<int> SubsequentUnitID { get; set; }
    [ForeignKey("SubsequentUnitID")]
    public virtual Unit SubsequentUnit { get; set; }
    }
