            private void TextBlock_Loaded(object sender, RoutedEventArgs e)
            {
                var country = (Country)((TextBlock)e.OriginalSource).DataContext;
                var states = country.States.Select(c => c.Area + " : " + c.Capital + " : " + c.Name);
    
                string state_string = "";
                foreach (string s in states)
                {
                    state_string = state_string + " ^ " + s;
                }
    
                ((TextBlock)e.OriginalSource).DataContext = state_string;
            }     
