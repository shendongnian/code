    public interface IUser {
        string Name { get; set; }
    }
    public interface ISettings<out TUser>
        where TUser : IUser {
        IEnumerable<TUser> Users { get; }
    }
    public interface IPage<out TUser>
        where TUser : IUser {
        ISettings<TUser> Settings { get; }
    }
    
    // Abstract implementation
    public abstract class SettingsBase<TUser> : ISettings<TUser
        where TUser : IUser {
        public SettingsBase() {
            Users = new ObservableCollection<TUser>();
        }
        public IEnumerable<TUser> Users { get; private set; }
    }
    public abstract class Page<TUser> : IPage<TUser>
        where TUser : IUser {
        public Page() {
            Settings = CreateSettings();
        }
        public ISettings<TUser> Settings { get; private set; }
        //
        protected abstract ISettings<TUser> CreateSettings();
    }
    // Real implementation
    public class ConfigPage : Page<User> {
        protected override ISettings<User> CreateSettings() {
            return new Settings();
        }
    }
    public class User : IUser {
        public string Name { get; set; }
    }
    public class Settings : SettingsBase<User> {
        // ...
    }
