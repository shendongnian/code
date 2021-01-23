    private void button1_Click(object sender, RoutedEventArgs e)
    {
    
       Task.Factory.StartNew( () => { 
    
            employee.EmployeeNum = 123;
            System.Threading.Thread.Sleep(3000);
            employee.FirstName = "John";
            System.Threading.Thread.Sleep(3000);
            employee.LastName = "kepler"; }
       );
          
    }
