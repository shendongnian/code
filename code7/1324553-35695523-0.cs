                String stringToTestIsEmpty = row[i].ToString();
                //Check if it is not an empty line
                if( ! String.IsNullOrWhiteSpace(stringToTestIsEmpty ))
                {
                    resutl.Append(stringToTestIsEmpty);
                }
