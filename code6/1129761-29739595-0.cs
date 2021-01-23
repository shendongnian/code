    RaiseEvent.ProgressUpdate += (s, e) =>
            {
                Dispatcher.BeginInvoke((Action)(() => 
                                            { 
                                                lstTest.Items.Add("this is a test : "); 
                                                //Add items to your UI control here...
                                            }));
            };
