        Public string GetMessage(Program program)
        {
        
          if(DateTime.Now > Program.DueDate)
            return string.Format("Due date for Programming Assignment {0} has been reached {1}.",Program.Name,Program.DueDate);    
          else
            string.Format("Days remaining until Programming Assignment {0} deadline: {1}",Program.Name,Program.DueDate);
        
        }
