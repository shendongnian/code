c#
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
public string CustomerName { get; set; }
It appears that this annotation does the trick, in that the field gets filled by SQLQuery and there's no complaint during an update (`DbContext.SaveChanges()`), even if the column is not present in the Db table.
Whereas a similar annotation `DatabaseGenerated(DatabaseGeneratedOption.Computed)` expects to find such a column in the table.
