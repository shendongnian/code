    public async void button1_Click( object sender , EventArgs e)
    {
        for(int i=0;i<100;i++)
        {
            Progress1.Value +=1;
            await Task.Delay(10);
        }
    }
