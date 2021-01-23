        private static XmlNode currentIterationNode;
        TfsTeamProjectCollection tpc = TFSConncetion(@"http://tfs/url");
        ICommonStructureService4 css = tpc.GetService<ICommonStructureService4>();;
        WorkItemStore workItemStore = new WorkItemStore(tpc);
            foreach (Project teamProject in workItemStore.Projects)
            {
                if (teamProject.Name.Equals("TeamProjectNameGoesHere"))
                {
                    NodeInfo[] structures = css.ListStructures(teamProject.Uri.ToString());
                    NodeInfo iterations = structures.FirstOrDefault(n => n.StructureType.Equals("ProjectLifecycle"));
                    if (iterations != null)
                    {
                        XmlElement iterationsTree = css.GetNodesXml(new[] { iterations.Uri }, true);
                        XmlNodeList nodeList = iterationsTree.ChildNodes;
                        currentIterationNode = FindCurrentIteration(nodeList);
                        String currentIterationPath = currentIterationNode.Attributes["Path"].Value;
                    }
                }
            }
