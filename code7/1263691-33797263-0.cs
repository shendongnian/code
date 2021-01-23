            Dictionary<string, string> morseDictonary = new Dictionary<string, string>();
            morseDictonary.Add(".", ".-.-.-");  //*** Important: Do this first ***
            morseDictonary.Add(",", "--..--");
            morseDictonary.Add(" ", " ");
            morseDictonary.Add("A", ".-");
            morseDictonary.Add("B", "-...");
            //...
            string example = "A , B .";
            foreach(KeyValuePair<string, string> pair in morseDictonary)
            {
                example = example.Replace(pair.Key, pair.Value);
            }
            //example = ".- --..-- -... .-.-.-"
