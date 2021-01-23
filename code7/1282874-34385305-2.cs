    public interface IViewModel<T>
    {
        void EditItem(T item);
    }
    class UserEditViewModel : IViewModel<User>
    {
        public void EditItem(User item)
        {
            // bind properties etc...
        }
    }
