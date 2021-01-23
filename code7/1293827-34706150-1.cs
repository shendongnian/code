    public abstract partial class Class1<T> where T : Class1<T>, new()
    {
        protected abstract void Load(dynamic row);
    
        private static T GetItem(dynamic row)
        {
            var item = new T();
            if (row != null)
                item.Load(row);
            return item;        
        }
    
        public static T GetDetails(long ID)
        {
            var row = Shared.SessionWrapper.Current.globaldbcon.QuerySingle("SELECT * FROM [" 
                + EntityLayout.ContainerName + "].["
                + EntityLayout.TableName + "] WHERE ID=@0", ID);
            return GetItem(row);
        }
    
        public static List<T> ListAll()
        {
            List<T> result = new List<T>();
            foreach (var row in Shared.SessionWrapper.Current.globaldbcon.Query("SELECT * FROM [" 
                + EntityLayout.ContainerName + "].["
                + EntityLayout.TableName + "]")) result.Add(GetItem(row));
            return result;
        }
    }
