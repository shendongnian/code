    string[] list = new string[] { "Jonathan Spielberg", "Stephanie Black", "Marcus Smith", "Kylie Ashton" };
                    
    Document mainDoc = new Document(MyDir + "in.docx");
    mainDoc.Range.Replace(new Regex("######CANDIDATESNAME#####"), new FindandInsertList(list), false);
    mainDoc.Save(MyDir + " Out.docx");
    //--------------------------------------
    public class FindandInsertList : IReplacingCallback
    {
        private string[] listitems;
                 
        public FindandInsertList(string[] list)
        {
            listitems = list;
        }
     
        ReplaceAction IReplacingCallback.Replacing(ReplacingArgs e)
        {
            // This is a Run node that contains either the beginning or the complete match.
            Node currentNode = e.MatchNode;
     
            // The first (and may be the only) run can contain text before the match,
            // in this case it is necessary to split the run.
            if (e.MatchOffset > 0)
                currentNode = SplitRun((Run)currentNode, e.MatchOffset);
     
            // This array is used to store all nodes of the match for further removing.
            ArrayList runs = new ArrayList();
     
            // Find all runs that contain parts of the match string.
            int remainingLength = e.Match.Value.Length;
            while (
                (remainingLength > 0) &&
                (currentNode != null) &&
                (currentNode.GetText().Length <= remainingLength))
            {
                runs.Add(currentNode);
                remainingLength = remainingLength - currentNode.GetText().Length;
     
                // Select the next Run node.
                // Have to loop because there could be other nodes such as BookmarkStart etc.
                do
                {
                    currentNode = currentNode.NextSibling;
                }
                while ((currentNode != null) && (currentNode.NodeType != NodeType.Run));
            }
     
            // Split the last run that contains the match if there is any text left.
            if ((currentNode != null) && (remainingLength > 0))
            {
                SplitRun((Run)currentNode, remainingLength);
                runs.Add(currentNode);
            }
     
            // Create Document Buidler
            DocumentBuilder builder = new DocumentBuilder(e.MatchNode.Document as Document);
     
            builder.MoveTo((Run)runs[runs.Count - 1]);
     
            builder.ListFormat.List = e.MatchNode.Document.Lists.Add(ListTemplate.NumberDefault);
     
     
            foreach (string item in listitems)
            {
                builder.Writeln(item);
            }
     
            // End the bulleted list.
            builder.ListFormat.RemoveNumbers();
                   
            // Now remove all runs in the sequence.
            foreach (Run run in runs)
                run.Remove();
     
            // Signal to the replace engine to do nothing because we have already done all what we wanted.
            return ReplaceAction.Skip;
        }
     
        private static Run SplitRun(Run run, int position)
        {
            Run afterRun = (Run)run.Clone(true);
            afterRun.Text = run.Text.Substring(position);
            run.Text = run.Text.Substring(0, position);
            run.ParentNode.InsertAfter(afterRun, run);
            return afterRun;
        }
    }
