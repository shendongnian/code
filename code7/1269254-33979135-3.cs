    public class QsaasUserStore<TLogin> : IUserStore<QsaasUser<TLogin>, int> where TLogin : QsaasUserLogin<int>
    {
        public Task CreateAsync(QsaasUser<TLogin> user)
        {
            var session = NHibertnateSessionProvidser.SessionFactory.GetCurrentSession();
            session.Save(user);
            return Task.FromResult(0);
        }
    }
