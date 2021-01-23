        public static string GetMovieTitle(string json, string enteredNumberText)
        {
            var root = JsonConvert.DeserializeObject<RootObject>(json);
            try
            {
                var enteredNumber = Int32.Parse(enteredNumberText);
                if (enteredNumber < 0 || enteredNumber >= root.movies.Count)
                    return null;
                return root.movies[enteredNumber].title;
            }
            catch (System.FormatException)
            {
                // Invalid number typed by the user.  Handle if desired.
                throw;
            }
            catch (System.OverflowException)
            {
                // Too large or small number typed by the user.  Handle if desired.
                throw;
            }
        }
