    namespace ConnectionStringCustom
    {
    	public static class ExampleData
    	{
    		public static String connUserName = "user";
    		public static String connPassword = "pass";
    		public static String connServerName = "servername";
    		public static String connDatabaseName = "databasename";
    	}
    }
    
    
    
    namespace ConnectionStringCustom.Properties
       {
    
       internal sealed partial class Settings
          {
    
    
          void Settings_SettingsLoaded( object sender, System.Configuration.SettingsLoadedEventArgs e )
             {
    			 this["CustomConnectionString"] = "Data Source=" + ExampleData.connServerName + ";"
    										  + "Initial Catalog=" + ExampleData.connDatabaseName + ";"
                                              + "Persist Security Info=false;"
    										  + "User ID=" + ExampleData.strConnUserName + ";"
    										  + "Password=" + ExampleData.connPassword + ";";
             }
    
          }
    
       }
