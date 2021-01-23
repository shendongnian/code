        static void Main() {
            var git = Git.Init().SetDirectory("C:\\MyGitRepo").Call();            
            string relativePath = "MyFolder/MyFile.cs";            
            var blameHunks = git.Blame().SetFilePath(relativePath).SetTextComparator(RawTextComparator.WS_IGNORE_ALL).Call();
            blameHunks.ComputeAll();
            var firstLineCommit = blameHunks.GetSourceCommit(0);
            // next : find the hunk which overlap the desired line number
            Console.ReadKey();
        }
