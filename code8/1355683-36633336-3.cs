    public class MyModel 
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateChosen { get; set; }
   
        public string DateChosenString
        {
            return DateChosen.ToString("yyyy-MM-dd");
        }     
        // Other properties goes there
    }
