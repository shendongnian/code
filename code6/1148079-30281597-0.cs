    private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Test";
            MyAsyncMethod();
        }
    public async Task MyAsyncMethod()
    {
        return await Task.Run(() =>{
        label1.Text = "";
        //everything from here on will not be executed
         }
    }
