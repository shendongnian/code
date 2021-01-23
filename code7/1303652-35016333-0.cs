    public class Unit
    {
    public int UnitID { get; set; }
    public Nullable<int> PreviousUnitID { get; set; }
    public Nullable<int> SubsequentUnitID { get; set; }
    public Virtual PreviousUnit { get; set; }
    public Virtual SubsequentUnit { get; set; }
    }
