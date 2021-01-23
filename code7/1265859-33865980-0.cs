    var currentHeader = null;
    while ((line = file.ReadLine()) != null)
    {
        Match match = regex.Match(line); //Match Header
        Match matchSub = regexSub.Match(line);//Match Detail
     
        if (match.Success)
        {
            currentHeader = new TreeNode();
            currentHeader .Text = line;
            treeCards.Nodes.Add(currentHeader);
        }
        else if (matchSub.Success)
        {
            var newNode = new TreeNode();
            newNode.Text = line;
            currentHeader.Nodes.Add(newNode1);
        }
        counter++;
    }
