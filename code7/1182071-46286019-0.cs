    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    namespace GlobalVariables
    {
        /// <summary>
        /// Summary description for Globals
        /// See https://www.codeproject.com/Questions/233650/How-to-define-Global-veriable-in-Csharp-net
        /// </summary>
        public static class Globals
        {
            //  Note that now the obsolete code now only leaves one warning
            //  for the block excluded code:
            //      Unreachable code detected
            //  instead of a warning line for each instance of obsolete code.
            //  The "Unreachable code detected" can be disabled and enabled with 
            //  #pragma warning disable 162 
            //  #pragma warning enable 162 
            public const bool UAT = true;
            static Globals()
            {
                //
                // TODO: Add constructor logic here
                //
            }
        }
    }
