            // Lowered bad words array
            string[] badWordArray = { "abadword1", "abadword2", "abadword3" };
            bool isBadWord = false;
            if (! string.IsNullOrEmpty(name))
            {
                isBadWord = badWordArray.Any(badWord => name.ToLower().Contains(badWord));
            }
