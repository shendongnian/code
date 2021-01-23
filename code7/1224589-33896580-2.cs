    public class MyParentClassEntity : IId
    {
        public int Id { get; set; }
        . . .
    [TablePerConcrete]
    [ForcePKId]
    public class MySubclassTable : MyParentClassEntity
    {
        // No need for  PK/Id property here, it was inherited and will work as
        // you intended.
