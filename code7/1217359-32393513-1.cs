            foreach (var data in csv) // csv is a string[] -> data is a string
            {
                // data is a string which is basically a char[] -> cell is a char
                // I don't think, that's what you wanted...
                foreach (var cell in data) 
                {
                    var newline = string.Format("{0}", cell);
                    newline = cell != data[4] ? newline + "," : newline;
                    sw.Write(newline);
                }
                sw.Write(Environment.NewLine);
            }
