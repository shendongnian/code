    i got the output: did it as below 
    Config file 
    <configuration>
      <!--<configSections>
        <section name="QuerySettings" type="System.Configuration.NameValueSectionHandler"/>
        <section name="QuerySettings" type="CustomConfigApp.ConfigHelper, CustomConfigApp"/>
    
      </configSections>
      <QuerySettings>
        <add key="Qry1" value="Select * from table" />
        <add key="Qry2" value="delete from table" />
      </QuerySettings>-->
      <appSettings>
        <add key="Qry1" value="Select * from table" />
        <add key="Qry2" value="delete from table" />
      </appSettings>
    </configuration>
    
    class file 
    class sample
        {
              public string Qry1
            { get; set; }
              public string Qry2
            { get; set; }
             
        }
    sample s1 = new sample();
     var QueryConfigKey = ConfigurationManager.AppSettings;S
                if (QueryConfigKey != null)
                {
                    foreach (var serverKey in QueryConfigKey.AllKeys)
                    {
                        string serverValue = QueryConfigKey.GetValues(serverKey).FirstOrDefault();
                        //Console.WriteLine(serverValue);
                      PropertyInfo propertyInfo = s1.GetType().GetProperty(serverKey);
                      propertyInfo.SetValue(s1, Convert.ChangeType(serverValue, propertyInfo.PropertyType),null);
                        
                    }
                }
                string query1 = s1.Qry1;
                string query2 = s1.Qry2;
    
    
                Console.WriteLine(query1);
                Console.WriteLine(query2);`enter code here`
                Console.ReadLine();
