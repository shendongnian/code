    <!--Context.Dbc is the namespace qualified class of my context. Context is the DLL that it is found in.-->
    <!--Context.ContextInitalizer is the namespace qualified class of my custom initializer. Context is the DLL that it is found in.-->
    <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <!-- This specifies that EF has an initializer -->
        <contexts>
          <context type="Context.Dbc, Context">
            <databaseInitializer type="Context.ContextInitializer, Context"></databaseInitializer>
          </context>
        </contexts>
        <!--End initializer-->
    </entityFramework>
