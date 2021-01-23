    public async Task<string> test()
    {
         // put all of the web service setup code here, then:
     
         string result = await ptc.getODIAsync("1");
         return result; 
    }
    // add async here so that the Click event can use Tasks with await/async
    private async void button_Click(object sender, RoutedEventArgs e)
    {
        // stuff the value when the response returns from test
        textBlock.Text = await test();
    }
