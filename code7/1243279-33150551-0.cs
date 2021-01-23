        public static List<string> RemoveAllNonAlphanumeric(List<string> Input)
        {
            var TempList = new List<string>();
            foreach (var CurrentString in Input)
            {
                if (Regex.IsMatch(CurrentString, "[a-zA-Z0-9]+"))
                {
                    TempList.Add(CurrentString);
                }
            }
            return Input;
        }
