    public class Enrolment
    {
         public IEnumerable<ListItem> ToDoList{ get; private set; }
    
         public void ApplyJSON(string json)
         {
              //Magic :)
              YourList = JsonConvert.DeserializeObject<IEnumerable<ListItem>>(json);
         }
    }
