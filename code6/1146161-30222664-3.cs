    public void Do()
    {
       if (s.Contains("php")||s.Contains("echo"))
       { 
            HD.Text = "this php ?";
            Task.Delay(TimeSpan.FromSeconds(10)).Wait();
            MessageBox.Show("Its Php ?","Guss"); 
       }
    }
