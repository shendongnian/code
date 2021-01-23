            public class MyModelView
            {
               public IEnumerable<SelectListItem> Skills{ get; set; }
               public string[] SelectedSkills { get; set; } // You could use      List<string> instead. 
               public int TeacherId {get;set;}
            }
           
