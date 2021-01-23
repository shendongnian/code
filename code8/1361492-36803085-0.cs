    // Split your string, removing any empty entries
    var output = strings.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => {
                             // A variable to store your value
                             int v;
                             // Attempt to parse it, store an indicator if the parse was
                             // successful (and store the value in your v parameter)
                             var success = Int32.TryParse(n, out v);
                             // Return an object containing your value and if it was successful
                             return new { Number = v, Successful = success };
                        })
                        // Now only select those that were successful
                        .Where(attempt => attempt.Successful)
                        // Grab only the numbers for the successful attempts
                        .Select(attempt => attempt.Number)
                        // Place this into an array
                        .ToArray();
