           public class TableViewModelComparer : IEqualityComparer<TableViewModel>
           {
               public bool Equals(TableViewModel x, TableViewModel y)
               {
                   return x.QOrder == y.QOrder;
               }
           
               public int GetHashCode(TableViewModelobj)
               {
                   return obj.QOrder.GetHashCode();
               }
           }
