    private void navnumbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBoxesMap = new Dictionary<int,TextBox>()
        {
            {1, One},
            {2, Two}
            // etc
        };
    
        try
        {
            int number = int.Parse(navnumbox.Text)
            foreach(var item in textBoxesMap)
            {
                if(item.Key <= number)
                {
                    item.Value.IsEnabled = true;
                }
            }
        }
    }
