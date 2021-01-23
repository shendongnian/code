    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.SqlServer.Dts.Runtime;
    namespace ST_6fabd2d80a6340399c540f8fdeaebf97
    {
        /// <summary>
        /// StackOverflow 36362799
        /// </summary>
        [Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
        public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
        {
            /// <summary>
            /// Determine if all the files in our expected set match the actual set
            /// </summary>
            public void Main()
            {
                var expected = new List<string>() { @"C:\ssisdata\so\input\so_36362799_a.txt", @"C:\ssisdata\so\input\so_36362799_b.txt" };
                var actual = System.IO.Directory.GetFiles(@"C:\ssisdata\so\input", "so*.txt");
                bool pokemon = expected.Count() == expected.Intersect(actual).Count();
                if (pokemon)
                {
                    Dts.TaskResult = (int)ScriptResults.Success;
                }
                else
                {
                    Dts.TaskResult = (int)ScriptResults.Failure;
                }
            }
            enum ScriptResults
            {
                Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
                Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
            };
        }
    }
