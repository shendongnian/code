            // Summary:
            //     Writes the text representation of the specified object, followed by the current
            //     line terminator, to the standard output stream using the specified format
            //     information.
            //
            // Parameters:
            //   format:
            //     A composite format string (see Remarks).
            //
            //   arg0:
            //     An object to write using format.
            //
            // Exceptions:
            //   System.IO.IOException:
            //     An I/O error occurred.
            //
            //   System.ArgumentNullException:
            //     format is null.
            //
            //   System.FormatException:
            //     The format specification in format is invalid.
            public static void WriteLine(string format, object arg0);
