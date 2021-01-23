    public class DataFeedback
    {
        [Display(Name = "Row Num", Order = 0)]
        [GridColumn(Width = "100px")]
        public int RowNum { get; set; }
        
        [Display(Name = "Description", Order = 1)]
        [GridColumn(Width = "300px")]
        public string Desc { get; set; }   
     }
