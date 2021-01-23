csharp
    public class AesDataProtectorTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public AesDataProtectorTokenProvider(IOptions<DataProtectionTokenProviderOptions> options, ISettingSupplier settingSupplier)
            : base(new AesProtectionProvider(settingSupplier.Supply()), options)
        {
            var settingsLifetime = settingSupplier.Supply().Encryption.PasswordResetLifetime;
            if (settingsLifetime.TotalSeconds > 1)
            {
                Options.TokenLifespan = settingsLifetime;
            }
        }
    }
csharp
    public class AesProtectionProvider : IDataProtectionProvider
    {
        private readonly SystemSettings _settings;
        public AesProtectionProvider(SystemSettings settings)
        {
            _settings = settings;
            if(string.IsNullOrEmpty(_settings.Encryption.AESPasswordResetKey))
                throw new ArgumentNullException("AESPasswordResetKey must be set");
        }
        public IDataProtector CreateProtector(string purpose)
        {
            return new AesDataProtector(purpose, _settings.Encryption.AESPasswordResetKey);
        }
    }
csharp
    public class AesDataProtector : IDataProtector
    {
        private readonly string _purpose;
        private readonly SymmetricSecurityKey _key;
        private readonly Encoding _encoding = Encoding.UTF8;
        public AesDataProtector(string purpose, string key)
        {
            _purpose = purpose;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
        public byte[] Protect(byte[] userData)
        {
            return AESThenHMAC.SimpleEncryptWithPassword(userData, _encoding.GetString(_key.Key));
        }
        public byte[] Unprotect(byte[] protectedData)
        {
            return AESThenHMAC.SimpleDecryptWithPassword(protectedData, _encoding.GetString(_key.Key));
        }
        public IDataProtector CreateProtector(string purpose)
        {
            throw new NotSupportedException();
        }
    }
and the SettingsSupplier i use in my project to supply my settings
csharp
    public interface ISettingSupplier
    {
        SystemSettings Supply();
    }
    public class SettingSupplier : ISettingSupplier
    {
        private IConfiguration Configuration { get; }
        public SettingSupplier(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public SystemSettings Supply()
        {
            var settings = new SystemSettings();
            Configuration.Bind("SystemSettings", settings);
            return settings;
        }
    }
    public class SystemSettings
    {
        public EncryptionSettings Encryption { get; set; } = new EncryptionSettings();
    }
    public class EncryptionSettings
    {
        public string AESPasswordResetKey { get; set; }
        public TimeSpan PasswordResetLifetime { get; set; } = new TimeSpan(3, 0, 0, 0);
    }
finally register the provider in Startup:
csharp
 services
     .AddIdentity<AppUser, AppRole>()
     .AddEntityFrameworkStores<AppDbContext>()
     .AddDefaultTokenProviders()
     .AddTokenProvider<AesDataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
 services.AddScoped(typeof(ISettingSupplier), typeof(SettingSupplier));
csharp
//AESThenHMAC.cs: See https://gist.github.com/jbtule/4336842#file-aesthenhmac-cs
