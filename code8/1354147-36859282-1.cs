    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using log;
    namespace ConsoleApplication1
    {
        class Program
        {
            static System.Type className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
            static void Main( string[] args )
            {
                LoggerLib loggerLib = new LoggerLib();
                loggerLib.DeclareClass( className );
                loggerLib.LoggerSetup(".","test","Log4", "TestColoum");
            
            
                loggerLib.LogError( "TEXT5", "test4" );
            
                loggerLib.LogError( "TEXT3", "test3" );
           
            }
        }
    }
