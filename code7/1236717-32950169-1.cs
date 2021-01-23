        public static Model taped;
         void SelectionChanged(object sender, SelectionChangedEventArgs    e)
        {
          var list= sender as Listview;
          taped=list.SelectedItem as Model;
          
          
        }
