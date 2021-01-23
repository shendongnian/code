     private void Window_Loaded(object sender, RoutedEventArgs e)
            {
    
                Task.Run((Action)TryExecute).Catch<Exception>((r) => Console.WriteLine("Caught Exception {0}", r));
            }
    
            private static void TryExecute()
            {
                throw new NotImplementedException();
            }
