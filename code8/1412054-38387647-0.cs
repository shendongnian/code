    public abstract class AStar<T>
    {
        #region Fields
        private class Node
        {
            public T Position;
            public T PreviousPosition;
            public float F, G, H;
            public bool IsClosed;
        }
        private int m_nodesCacheIndex;
        private List<Node> m_nodesCache = new List<Node>();
        private List<Node> m_openHeap = new List<Node>();
        private List<T> m_neighbors = new List<T>();
        private Dictionary<T, object> m_defaultStorage;
        #endregion
        #region Domain Definition
        // User must override Neighbors, Cost and Heuristic functions to define search domain.
        // It is optional to override StorageClear, StorageGet and StorageAdd functions. 
        // Default implementation of these storage functions uses a Dictionary<T, object>, this works for all possible search domains. 
        // A domain-specific storage algorihm may be significantly faster.
        // For example if searching on a finite 2D or 3D grid, storage using fixed array with each element representing one world point benchmarks an order of magnitude faster.
        /// <summary>
        /// Return all neighbors of the given point.
        /// Must be overridden.
        /// </summary>
        /// <param name="p">Point to return neighbors for</param>
        /// <param name="neighbors">Empty collection to fill with neighbors</param>
        protected abstract void Neighbors(T p, List<T> neighbors);
        /// <summary>
        /// Return cost of making a step from p1 to p2 (which are neighbors).
        /// Cost equal to float.PositiveInfinity indicates that passage from p1 to p2 is impossible.
        /// Must be overridden.
        /// </summary>
        /// <param name="p1">Start point</param>
        /// <param name="p2">End point</param>
        /// <returns>Cost value</returns>
        protected abstract float Cost(T p1, T p2);
        /// <summary>
        /// Return an estimate of cost of moving from p to nearest goal.
        /// Must return 0 when p is goal.
        /// This is an estimate of sum of all costs along the best path between p and the nearest goal.
        /// This should not overestimate the actual cost; if it does, the result of A* might not be an optimal path.
        /// Underestimating the cost is allowed, but may cause the algorithm to check more positions.
        /// Must be overridden.
        /// </summary>
        /// <param name="p">Point to estimate cost from</param>
        /// <returns>Cost value</returns>
        protected abstract float Heuristic(T p);
        /// <summary>
        /// Clear A* storage.
        /// This will be called every time before a search starts and before any other user functions are called.
        /// Optional override when using domain-optimized storage.
        /// </summary>
        protected virtual void StorageClear()
        {
            if (m_defaultStorage == null)
            {
                m_defaultStorage = new Dictionary<T, object>();
            }
            else
            {
                m_defaultStorage.Clear();
            }
        }
        /// <summary>
        /// Retrieve data from storage at given point.
        /// Optional override when using domain-optimized storage.
        /// </summary>
        /// <param name="p">Point to retrieve data at</param>
        /// <returns>Data stored for point p or null if nothing stored</returns>
        protected virtual object StorageGet(T p)
        {
            object data;
            m_defaultStorage.TryGetValue(p, out data);
            return data;
        }
        /// <summary>
        /// Add data to storage at given point.
        /// There will never be any data already stored at that point.
        /// Optional override when using domain-optimized storage.
        /// </summary>
        /// <param name="p">Point to add data at</param>
        /// <param name="data">Data to add</param>
        protected virtual void StorageAdd(T p, object data)
        {
            m_defaultStorage.Add(p, data);
        }
        #endregion
        #region Public Interface
        /// <summary>
        /// Find best path from start to nearest goal.
        /// Goal is any point for which Heuristic override returns 0.
        /// If maxPositionsToCheck limit is reached, best path found so far is returned.
        /// If there is no path to goal, path to a point nearest to goal is returned instead.
        /// </summary>
        /// <param name="path">Path will contain steps to reach goal from start in reverse order (first step at the end of collection)</param>
        /// <param name="start">Starting point to search for path</param>
        /// <param name="maxPositionsToCheck">Maximum number of positions to check</param>
        /// <returns>True when path to goal was found, false if partial path only</returns>
        public bool FindPath(ICollection<T> path, T start, int maxPositionsToCheck = int.MaxValue)
        {
            // Check arguments
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            // Reset cache and storage
            path.Clear();
            m_nodesCacheIndex = 0;
            m_openHeap.Clear();
            StorageClear();
            // Put start node
            Node startNode = NewNode(start, default(T), 0, 0);
            StorageAdd(start, startNode);
            HeapEnqueue(startNode);
            // Astar loop
            Node bestNode = null;
            int checkedPositions = 0;
            while (true)
            {
                // Get next node from heap
                Node currentNode = m_openHeap.Count > 0 ? HeapDequeue() : null;
                // Check end conditions
                if (currentNode == null || checkedPositions >= maxPositionsToCheck)
                {
                    // No more nodes or limit reached, path not found, return path to best node if possible
                    if (bestNode != null)
                    {
                        BuildPathFromEndNode(path, startNode, bestNode);
                    }
                    return false;
                }
                else if (Heuristic(currentNode.Position) <= 0)
                {
                    // Node is goal, return path
                    BuildPathFromEndNode(path, startNode, currentNode);
                    return true;
                }
                // Remember node with best heuristic; ignore start node
                if (currentNode != startNode && (bestNode == null || currentNode.H < bestNode.H))
                {
                    bestNode = currentNode;
                }
                // Move current node from open to closed in the storage
                currentNode.IsClosed = true;
                ++checkedPositions;
                // Try all neighbors
                m_neighbors.Clear();
                Neighbors(currentNode.Position, m_neighbors);
                for (int i = 0; i < m_neighbors.Count; ++i)
                {
                    // Get position
                    T position = m_neighbors[i];
                    // Get existing node at position, if any
                    Node node = (Node)StorageGet(position);
                    // If position was already analyzed, ignore step
                    if (node != null && node.IsClosed == true)
                    {
                        continue;
                    }
                    // If position is not passable, ignore step
                    float cost = Cost(currentNode.Position, position);
                    if (cost == float.PositiveInfinity)
                    {
                        continue;
                    }
                    // Calculate A* values
                    float g = currentNode.G + cost;
                    float h = Heuristic(position);
                    // Update or create new node at position
                    if (node != null)
                    {
                        // Update existing node if better
                        if (g < node.G)
                        {
                            node.G = g;
                            node.F = g + node.H;
                            node.PreviousPosition = currentNode.Position;
                            HeapUpdate(node);
                        }
                    }
                    else
                    {
                        // Create new open node if not yet exists
                        node = NewNode(position, currentNode.Position, g, h);
                        StorageAdd(position, node);
                        HeapEnqueue(node);
                    }
                }
            }
        }
        #endregion
        #region Internals
        private void BuildPathFromEndNode(ICollection<T> path, Node startNode, Node endNode)
        {
            for (Node node = endNode; node != startNode; node = (Node)StorageGet(node.PreviousPosition))
            {
                path.Add(node.Position);
            }
        }
        private void HeapEnqueue(Node node)
        {
            m_openHeap.Add(node);
            HeapifyFromPosToStart(m_openHeap.Count - 1);
        }
        private Node HeapDequeue()
        {
            Node result = m_openHeap[0];
            if (m_openHeap.Count <= 1)
            {
                m_openHeap.Clear();
            }
            else
            {
                m_openHeap[0] = m_openHeap[m_openHeap.Count - 1];
                m_openHeap.RemoveAt(m_openHeap.Count - 1);
                HeapifyFromPosToEnd(0);
            }
            return result;
        }
        private void HeapUpdate(Node node)
        {
            int pos = -1;
            for (int i = 0; i < m_openHeap.Count; ++i)
            {
                if (m_openHeap[i] == node)
                {
                    pos = i;
                    break;
                }
            }
            HeapifyFromPosToStart(pos);
        }
        private void HeapifyFromPosToEnd(int pos)
        {
            while (true)
            {
                int smallest = pos;
                int left = 2 * pos + 1;
                int right = 2 * pos + 2;
                if (left < m_openHeap.Count && m_openHeap[left].F < m_openHeap[smallest].F)
                    smallest = left;
                if (right < m_openHeap.Count && m_openHeap[right].F < m_openHeap[smallest].F)
                    smallest = right;
                if (smallest != pos)
                {
                    Node tmp = m_openHeap[smallest];
                    m_openHeap[smallest] = m_openHeap[pos];
                    m_openHeap[pos] = tmp;
                    pos = smallest;
                }
                else
                {
                    break;
                }
            }
        }
        private void HeapifyFromPosToStart(int pos)
        {
            int childPos = pos;
            while (childPos > 0)
            {
                int parentPos = (childPos - 1) / 2;
                Node parentNode = m_openHeap[parentPos];
                Node childNode = m_openHeap[childPos];
                if (parentNode.F > childNode.F)
                {
                    m_openHeap[parentPos] = childNode;
                    m_openHeap[childPos] = parentNode;
                    childPos = parentPos;
                }
                else
                {
                    break;
                }
            }
        }
        private Node NewNode(T position, T previousPosition, float g, float h)
        {
            while (m_nodesCacheIndex >= m_nodesCache.Count)
            {
                m_nodesCache.Add(new Node());
            }
            Node node = m_nodesCache[m_nodesCacheIndex++];
            node.Position = position;
            node.PreviousPosition = previousPosition;
            node.F = g + h;
            node.G = g;
            node.H = h;
            node.IsClosed = false;
            return node;
        }
        #endregion
    }
