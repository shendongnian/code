    public class SettingsInstaller : IWindsorInstaller
    {
    	private static MySettings Settings { get; set; }
    
    	public void Install(IWindsorContainer container, IConfigurationStore store)
    	{
    		UpdateSettings();
    
    		container.Register(
    			Component.For<MySettings>()
    			.UsingFactoryMethod(() =>
    			{
    				return SettingsInstaller.Settings;
    			})
    			.LifestyleTransient());
    	}
    
    	public static MySettings UpdateSettings()
    	{
    		using (DbContext db = new DbContext())
    		{
    			SettingsInstaller.Settings = db.Settings
    				.AsNoTracking()
    				.FirstOrDefault();
    		}
    
    		return SettingsInstaller.Settings;
    	}
    }
