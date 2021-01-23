     string datatxt;
        try
        {      
            StreamReader sr = new StreamReader("Data.txt");
            datatxt = sr.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error har occured: '{0}'", ex);
        }
        if (UserBox.Text.Equals(user) && PassBox.Text.Equals(data + datatxt)) 
        {
            Main s = new Main(); 
            ss.Show();                  
            this.Hide(); 
         }
