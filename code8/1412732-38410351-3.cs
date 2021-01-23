            ModifierKeys mk = ModifierKeys.None | ModifierKeys.Alt | ModifierKeys.Shift | ModifierKeys.Control;
            List<ModifierKeys> mklist =
                mk
                .ToString() //convert the enum to string
                .Split(new[] { "," } , StringSplitOptions.RemoveEmptyEntries) //converts the string to Enumerable of string
                .Select(//converts each element of the list to an enum, and makes an Enumerable out of the newly-converted items
                    strenum =>
                    {
                        ModifierKeys outenum;
                        Enum.TryParse(strenum , out outenum);
                        return outenum;
                    })
                .ToList(); //creates a List from the Enumerable
  
