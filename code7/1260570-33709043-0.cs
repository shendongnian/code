    internal class MovieEntryParser
    {
        internal static string DecrementAvailability( string input )
        {
            string[] details = input.Split( ';' );
            // relevant error checking
            int availability = int.Parse( details[ 2 ] ); // use try parse
            availability--;
            return string.Format( "{0};{1};{2}", details[ 0 ], details[ 1 ], availability );
        }
    }
