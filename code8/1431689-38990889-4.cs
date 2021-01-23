    <TextBox x:Name="HeaderSearch" Padding="5,5,5,0"
           Width="{TemplateBinding Width}" TextAlignment="Center" 
           GotFocus="HeaderSearch_GotFocus" />
    
    TextBox CodeHeaderSearch;
    TextBox NameHeaderSearch;
     private void HeaderSearch_GotFocus(object sender, RoutedEventArgs e)
     {
         TextBox t = sender as TextBox;
         var header = GetGridViewColumnHeader(t);
         if (header == "Code")
         {
             CodeHeaderSearch = sender as TextBox;
         }
         else if (header == "Name")
         {
             NameHeaderSearch = sender as TextBox;
         }
         // ....
     }
     private string GetGridViewColumnHeader(TextBox t)
     {
         var GridViewColumn = FindParent<GridViewColumnHeader>(t);
         return GridViewColumn.Column.Header as string;
     }
    
     public static T FindParent<T>(DependencyObject child) where T : DependencyObject
     {
         //get parent item
         DependencyObject parentObject = VisualTreeHelper.GetParent(child);
    
         //we've reached the end of the tree
         if (parentObject == null) return null;
    
         //check if the parent matches the type we're looking for
         T parent = parentObject as T;
         if (parent != null)
             return parent;
         else
             return FindParent<T>(parentObject);
     }
                 
