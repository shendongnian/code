    var TestTask = Task.Run(() =>
    {
                while (true)
                {
                    try
                    {
                        throw new Exception();
                    }                        
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);                            
                    }
                }
    });
