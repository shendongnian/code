     public partial class Graph
     {
        [Reference(ReferenceType.Many, ColumnName = "GraphId", 
         ReferenceMemberName = "GraphId")]
        [Column] public List<Plot> Plots { get; set; }
    ...
    [TableName("Graph")]
	[PrimaryKey("GraphId")]
	[ExplicitColumns]
    public partial class Graph : fooDB.Record<Graph>  
    {	
    ...
    
