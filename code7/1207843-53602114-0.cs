        private static QueryFolder GetQueryFolderFromPath(QueryFolder folder, string path)
        {
            var pathNodes = path.Split('/').Skip(1).ToArray();
            foreach(var node in pathNodes)
            {
                folder = (QueryFolder)folder[node];
                if (folder != null && folder.Path.Equals(path))
                    break;
            }
            return folder;
        }
