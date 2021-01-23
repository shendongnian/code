    public async Task Do()
    {
       if (s.Contains("php")||s.Contains("echo"))
       { 
            HD.Text = "this php ?";
            await Task.Delay(TimeSpan.FromSeconds(10));
            MessageBox.Show("Its Php ?","Guss"); 
       }
    }
