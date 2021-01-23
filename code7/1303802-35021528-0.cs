    public string Show_details(string Command = "Select name From panda")
    {
         SqlConnection cn = new SqlConnection(panda());
         SqlCommand Show;
         SqlDataReader read;
    
         Show = new SqlCommand(Command, cn);
         cn.Open();
    
         read = Show.ExecuteReader();
    
         // Declare flag to see if you've hit the reader yet.
         bool hasntYetRead = true;
    
         // Add a second condition to determine if to cursor through again
         while (read.Read() && hasntYetRead )
         {
            listBox1.Items.Add(read["name"]);
             
             // Change the flag to false
             hasntYetRead = false;
         }
    
         return Command;
    }
