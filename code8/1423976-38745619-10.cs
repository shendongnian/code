    public class SleepingMembersService
    {
        private readonly TimeStamp _lifetime = TimeStamp.FromMinutes(5);
        private readonly ICache _cache;
        private readonly INotifier _notifier;
        public SleepingMembersService(ICache cache, INotifier notifier)
        {
            _cache = cache;
            _notifier = notifier;
        }
        private string MakeKey(User user) => $"unsleepingUser{user.Id}";
        public void WakeUpIfSleep(IUser user)
        {
            var key = MakeKey(user);
            bool isWaking;
            if (_cache.TryGet(key, out isWaking) && isWaking)
                return;
            notifier.Notify(user.Id, "Wake up!");            
        }
        public void ConfirmImNotSleeping(IUser user)
        {
            var key = MakeKey(user);
            _cache.Add(key, _lifeTime, true);
        }
    }
