            private void PathfindingStep(Vector3 destination, float accuracyFactor)
        {
            calculatingStep++;
            PathNode currentNode;
            // Шаг 3.
            currentNode = openSet.OrderBy(node => node.EstimateFullPathLength).First();
            // Шаг 4.
            if (Vector3.Distance(currentNode.Position, destination) <= accurancy * accuracyFactor)
            {
                PathfindingComplete(CollapsePath(GetPathForNode(currentNode)).ToArray());
                return;
            }
            // Шаг 5.
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);
            // Шаг 6.
            List<PathNode> neighbours = GetNeighbours(currentNode, destination, accuracyFactor);
            foreach (PathNode neighbourNode in neighbours)
            {
                // Шаг 7.
                if (closedSet.Count(node => node.Position == neighbourNode.Position) > 0)
                    continue;
                PathNode openNode = openSet.Find(node => node.Position == neighbourNode.Position);
                // Шаг 8.
                if (openNode == null)
                    openSet.Add(neighbourNode);
                else if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                {
                    // Шаг 9.
                    openNode.CameFrom = currentNode;
                    openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                }
            }
        }
