            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                bool isWhiteSpace = false;
                bool isComment = false;
                bool isPoint = false;
                isWhiteSpace = string.IsNullOrEmpty(line);
                if (!isWhiteSpace)
                {
                    isComment = (line[0] == '/') && (line[1] == '/');
                    isPoint = (line[0] == '(') && (line[line.Length - 1] == ')');
                }
                Debug.Log("Comment: " + isComment + ", Point: " + isPoint + ", WhiteSpace: " + isWhiteSpace + "Value: '" + line + "'");
                if (!isComment && !isPoint && !isWhiteSpace) { Application.Quit(); }
                else if (isPoint)
                {
                    //Strip parenthesis
                    line = line.Remove(line.Length - 1, 1).Remove(0, 1);
                    //break into float array
                    string[] arr = line.Split(',');
                    float xVal = float.Parse(arr[0]);
                    float yVal = float.Parse(arr[1]);
                    float zVal = float.Parse(arr[2]);
                    Vector3 currentVector = new Vector3(xVal, yVal, zVal);
                    results.Add(currentVector);
                }
            }
