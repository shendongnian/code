    public MyClass()
    {
    
       YourDateTimePickerId.Value = DateTime.Now.AddDays(1);
       MessageBox.Show(dateTimePicker1.Value.ToString());
    } 
