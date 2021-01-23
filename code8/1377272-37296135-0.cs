        //
        // Summary:
        //     Returns the names of the subdirectories (including their paths) that match the
        //     specified search pattern in the specified directory, and optionally searches
        //     subdirectories.
        //
        // Parameters:
        //   path:
        //     The relative or absolute path to the directory to search. This string is not
        //     case-sensitive.
        //
        //   searchPattern:
        //     The search string to match against the names of subdirectories in path. This
        //     parameter can contain a combination of valid literal and wildcard characters
        //     (see Remarks), but doesn't support regular expressions.
        //
        //   searchOption:
        //     One of the enumeration values that specifies whether the search operation should
        //     include all subdirectories or only the current directory.
        //
        // Returns:
        //     An array of the full names (including paths) of the subdirectories that match
        //     the specified criteria, or an empty array if no directories are found.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     path is a zero-length string, contains only white space, or contains one or more
        //     invalid characters. You can query for invalid characters by using the System.IO.Path.GetInvalidPathChars
        //     method.-or- searchPattern does not contain a valid pattern.
        //
        //   T:System.ArgumentNullException:
        //     path or searchPattern is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     searchOption is not a valid System.IO.SearchOption value.
        //
        //   T:System.UnauthorizedAccessException:
        //     The caller does not have the required permission.
        //
        //   T:System.IO.PathTooLongException:
        //     The specified path, file name, or both exceed the system-defined maximum length.
        //     For example, on Windows-based platforms, paths must be less than 248 characters
        //     and file names must be less than 260 characters.
        //
        //   T:System.IO.IOException:
        //     path is a file name.
        //
        //   T:System.IO.DirectoryNotFoundException:
        //     The specified path is invalid (for example, it is on an unmapped drive).
        public static string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
