    using System;
    namespace TimeParser {
        class Program {
            static TimeSpan GetTimeFromText( string text ) {
                if ( string.IsNullOrWhiteSpace( text ) ) {
                    return TimeSpan.Zero;
                }
                return TimeSpan.Parse( text );
            }
            static TimeSpan GetTimeFromDouble( double value ) {
                if ( value <= 0 ) {
                    return TimeSpan.Zero;
                }
                int hours = (int)Math.Floor( value );
                int minutes = (int)(( value - hours )*60);
                return new TimeSpan(0, hours, minutes, 0);
            }
            static TimeSpan GetAddedTime( string input, double time ) {
                var textTime = GetTimeFromText( input );
                return textTime.Add( GetTimeFromDouble( time ) );
            } 
 
            static void Main( string[] args ) {
                var totalTime = GetAddedTime( "8:30", 8.67 );
                Console.WriteLine( totalTime ); // 17.10
            }
        }
    }
