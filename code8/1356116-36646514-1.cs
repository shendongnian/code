    private void cacheList_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                foreach (var item in e.AddedItems)
                {
                    
                    (item as Menu.Passed).Selected=true
                }
            }
    private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
            {
        
             PassedData.RemoveAll(data => data.IsSelected == true);
        
             }
        
        
        
        
        
            public class PassedData
            {
                public string Name { get; set; }
                public double Value { get; set;}
        
                public bool IsSelected{get;set;}
        
                
            }
