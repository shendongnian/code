    public async void Roll()
        {
            if (Active)
            {
               for (int i=0;i<20;i++) //Number of rolls before showing final
               {
                   await Task.Delay(100);
                   label.Text = random.Next(1, 7).ToString();
                }
            }
        } 
