    public class MyModel 
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", 
               ApplyFormatInEditMode = true)]
        public DateTime DateChosen { get; set; }
   
        // Other properties goes there
    }
