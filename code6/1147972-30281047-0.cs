    public class Test
    {
        [Display(Name = "Time")]
        [Required(ErrorMessage = "Is required field. Format hh:mm (24 hour time)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm\:ss}")]
        public Nullable<System.TimeSpan> EventPerformance_Time { get; set; }
    }
    <div>
    @Html.LabelFor(m => m.EventPerformance_Time)
    <div>
        @Html.EditorFor(m => m.EventPerformance_Time)
    </div>
