    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //synchronous section
        var t = new TextBlock();
        t.Text = "TEXT1";
        dummyStack.Children.Add(t);
        Dispatcher.BeginInvoke(
            //asynchronous section
            ()=>{
                var t2 = new TextBlock();
                t2.Text = "TEXT2";
                // ... heavy calculations
                dummyStack.Children.Add(t2);
            }
        );
    }
