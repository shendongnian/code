    public class ListViewItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, 
             DependencyObject container)
        {
             Style st = new Style();
             st.TargetType = typeof(ListViewItem);
             Setter backGroundSetter = new Setter();
             backGroundSetter.Property = ListViewItem.BackgroundProperty;
             ListView listView = 
                 ItemsControl.ItemsControlFromItemContainer(container) 
                  as ListView;
            int index = 
            listView.ItemContainerGenerator.IndexFromContainer(container);
            if (index % 2 == 0)    <-- here your own criteria
            {
                backGroundSetter.Value = Brushes.LightBlue;
            }
            else
            {
                backGroundSetter.Value = Brushes.Beige;
            }
            st.Setters.Add(backGroundSetter);
            return st;
        }  
     }    
