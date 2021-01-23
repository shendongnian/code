    private void MyObject_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                
                if (!canMouseUp)
                {
                    canMouseUp= true;
                    e.Handled = true;
                }
                else
                {
                    mouseUpTimer.Start();
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    private void MyObject_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                try
                {
                    mouseUpTimer.Stop();
                    // Do what DoubleClick is supposed to do
                    canMouseUp = false;
                    e.Handled = true;
                }
                catch (Exception)
                {
    
                    throw;
                }
            }
    private void mouseUpTimer_Elapsed(object sender, ElapsedEventArgs e)
            {
                
                try
                {
                    // Do what Mouse up is supposed to do.
                }
                catch (Exception)
                {
                    
                }
            }
