    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    /* Needs references to:
     * 
     * System.Data
     * Microsoft.SqlServer.ConnectionInfo 
     * Microsoft.SqlServer.Management.Sdk.Sfc
     * Microsoft.SqlServer.Smo
     * Microsoft.SqlServer.SmoExtended
     */
      
    namespace CopyTablesExample
    {
        class Program
        {
            public class CopyTables : Transfer
            {
                public string SchemaName { get; set; }
                public string DatabaseName { get; set; }
                public string ServerName { get; set; }
                public IEnumerable<string> GetScript()
                {
                    //This is what we will return
                    IEnumerable<string> scriptStrings = null;
                    if (this.DatabaseName == null) {
                        throw new Exception("DatabaseName property not set.");
                    }
                    if (this.ServerName == null) {
                        throw new Exception("ServerName property not set.");
                    }
                    var server = new Server(new ServerConnection(ServerName));
                    this.Database = server.Databases[this.DatabaseName];
                    //Turn off all objects.  Below we will start turning on what we want.
                    //You may wish to add more object types.
                    this.CopyAllObjects = false;
                    if (this.SchemaName == null) {
                        //No schema means all tables
                        this.CopyAllTables = true;
                    }
                    else {
                        //A specific schema means all tables from that schema
                        this.CopyAllTables = false;
                        //We only want to copy tables in a specific schema.
                        List<Table> tablesToCopy = new List<Table>();
                        foreach (Table t in this.Database.Tables) {
                            if (t.Schema.Equals(this.SchemaName)) {
                                tablesToCopy.Add(t);
                            }
                        }
                        //Add specifically the tables we want which are from the schema we want
                        this.ObjectList.AddRange(tablesToCopy);
                    }
                    try {
                        scriptStrings = this.ScriptTransfer().Cast<string>();
                    }
                    catch (Exception ex) {
                        Console.WriteLine("We got an exception.");
                        throw;
                    }
                    return scriptStrings;
                }
            }
            static void Main(String[] Args)
            {
                //Only set a SchemaName in line below, when you want to restrict yourself to copying that schema's tables.
                CopyTables ct = new CopyTables() { ServerName = "xyz", DatabaseName = "abc", SchemaName = "junk" } ; 
                var copyTablesScript = ct.GetScript();
                //For validation, display the script as generated
                foreach (var item in copyTablesScript) {
                    Console.WriteLine(item);
                }
                var discard = Console.ReadKey();
            }
        }
    }
