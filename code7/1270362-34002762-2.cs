    public class DacPacUtility
    {
	    public void DeployDacPac( string connString, string dacpacPath, string targetDbName )
	    {
		    var dbServices = new DacServices( connString );
		    var dbPackage = DacPackage.Load( new FileStream( dacpacPath, FileMode.Open, FileAccess.Read ), DacSchemaModelStorageType.Memory, FileAccess.Read );
		    var dbDeployOptions = new DacDeployOptions()
		    {
			    SqlCommandVariableValues =
			    {
				    new KeyValuePair< string, string >( "debug", "false" )
			    },
			    CreateNewDatabase = true,
			    BlockOnPossibleDataLoss = false,
			    BlockWhenDriftDetected = false
		    };
		    dbServices.Deploy( dbPackage, targetDbName, upgradeExisting : true, options : dbDeployOptions );
	    }
    }
