    public async void button1_Click(object sender, EventArgs e)
    {
        //Execute CloneTable on a thread-pool thread
        var tables = await Task.Run(() => ExtensionMethods.CloneTable(table, 4));
    
        //Use the tables here. This code will run on the UI thread
        //so you can access any UI elements here
        ...
    }
