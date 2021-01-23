    paragph.Clear();
    foreach (string line in lines)
        {
            if (line.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                //MessageBox.Show((counter + 1).ToString() + ": " + line);
                paragph.Add((counter + 1).ToString());
                arrparagh = paragph.ToArray();
                toDisplay = string.Join(",", arrparagh);
                //MessageBox.Show(toDisplay);
            }
            counter++;
        }
        yield return filePath;
