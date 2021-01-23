    string datatxt;
        try
        {      
            StreamReader sr = new StreamReader("Data.txt");
            datatxt = sr.ReadLine();
           if (UserBox.Text.Equals(user) && PassBox.Text.Equals(data + datatxt)) 
            {
              Main s = new Main(); 
              ss.Show();                  
              this.Hide();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error har occured: '{0}'", ex);
        }
