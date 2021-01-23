       public class Task
        {
            static Task root = new Task(); 
            string name;
            DateTime startDate;
            DateTime endDate;
            List<Task> nextTask = new List<Task>();
        }​
