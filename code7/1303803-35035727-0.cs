    public string Show_details(string Command = "Select name From panda")
    {
         SqlConnection cn = new SqlConnection(panda());
         SqlCommand Show;
         SqlDataReader read;
         Show = new SqlCommand(Command, cn);
         cn.Open();
         read = Show.ExecuteReader();
         // declare counter
         int counter = 0;
         // Add a second condition to determine if to cursor through again
         while (read.Read() && counter < 1) //could get counter to count to user input number
         {
             listBox1.Items.Add(read["name"]);
             // Change the flag to false
             counter++;
         }
         return Command;
    }
