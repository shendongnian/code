        public static string StringFormat(this string Arg, string Format) {
            //extract alignment from string
            Regex reg = new Regex(@"{[-+]?\d+\,[-+]?(\d+)(?::[-+]?\d+)?}");
            Match m = reg.Match(Format);
            if (m != null) { //check if alignment exists
                int allignment = int.Parse(m.Groups[1].Value); //get alignment
                Arg = Arg.PadLeft(allignment); //pad left, you can make the length check here
                Format = Format.Remove(m.Groups[1].Index - 1, m.Groups[1].Length + 1); //remove alignment from format
            }
            return (string.Format(Format, Arg));
        }
