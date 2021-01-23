    public class Users :ObservableCollection<User>
    {
        public User GetById(int id)
        {
            return this.First(u => u.ID == id);
        }
    }
