    var tapGestureRecognizer = new TapGestureRecognizer();
    tapGestureRecognizer.Tapped += async (s, e) =>
    {                     
        await getEmployeepage(mainContact.managerID);                 
        await Navigation.PushAsync(new ManagerDetailsPage(data()));             
    };
    manager.GestureRecognizers.Add(tapGestureRecognizer);
&
    public async Task getEmployeepage(String searchvalue)
    {
        EmployeeDetailsPage employeeDetailsPage = null;
        try
        { 
            var client = new System.Net.Http.HttpClient();
    
            client.BaseAddress = new Uri("http://..........");
            var response = await client.GetAsync("criterion?empId=" + searchvalue);
            string jsonString = await response.Content.ReadAsStringAsync();                   
    
            //rest of the logic            
    
        }
    }
