        internal IUserEmailStore<TUser, TKey> GetEmailStore()
        {
            var cast = Store as IUserEmailStore<TUser, TKey>;
            if (cast == null)
            {
                throw new NotSupportedException(Resources.StoreNotIUserEmailStore);
            }
            return cast;
        }
