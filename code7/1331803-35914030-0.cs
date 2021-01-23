    Entry txtTest;    
    async public void loadData()
    {
        Label lblTest = new Label { Text = "Test", FontAttributes = FontAttributes.Bold };
        txtTest = new Entry();
    
        StackLayout stLTest = new StackLayout
        {
            Padding = new Thickness(10, 0, 0, 0),
            Children ={ 
                lblTest,
                txtTest
            }
        };  
        Content = stTest
    }
