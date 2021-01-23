                string imgURL = row[0].ToString();
                bool graphImageExists = graphImageExists(imgURL);
                if (graphImageExists)
                {
                }
                else
                {
                    row[0] = "my placeholder";
                }
