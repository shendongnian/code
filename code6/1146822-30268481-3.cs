    /// <summary>
    /// Represents the JSONNode class.
    /// </summary>
    public class JSONNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JSONNode"/> class.
        /// </summary>
        /// <param name="name">The name of the node.</param>
        /// <param name="value">The value of the node.</param>
        public JSONNode(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            this.Children = new Dictionary<string, JSONNode>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="JSONNode"/> class.
        /// </summary>
        /// <param name="name">The name of the node.</param>
        public JSONNode(string name)
            : this(name, string.Empty)
        {
        }
        /// <summary>
        /// Gets the name of the node.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the children of the node.
        /// </summary>
        public Dictionary<string, JSONNode> Children
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the value of the node.
        /// </summary>
        public string Value
        {
            get;
            private set;
        }
        /// <summary>
        /// Inserts a new node in the corresponding hierarchy.
        /// </summary>
        /// <param name="keyHierarchy">A list with entries who specify the hierarchy.</param>
        /// <param name="value">The value of the node.</param>
        /// <exception cref="System.ArgumentNullException">Is thrown if the keyHierarchy is null.</exception>
        /// <exception cref="System.ArgumentException">Is thrown if the keyHierarchy is empty.</exception>
        public void InsertInHierarchy(List<string> keyHierarchy, string value)
        {
            if (keyHierarchy == null)
            {
                throw new ArgumentNullException("keyHierarchy");
            }
            if (keyHierarchy.Count == 0)
            {
                throw new ArgumentException("The specified hierarchy list is empty", "keyHierarchy");
            }
            // If we are not in the correct hierarchy (at the last level), pass the problem
            // to the child.
            if (keyHierarchy.Count > 1)
            {
                // Extract the current hierarchy level as key
                string key = keyHierarchy[0];
                // If the key does not already exists - add it as a child.
                if (!this.Children.ContainsKey(key))
                {
                    this.Children.Add(key, new JSONNode(key));
                }
                // Remove the current hierarchy from the list and ...
                keyHierarchy.RemoveAt(0);
                // ... pass it on to the just inserted child.
                this.Children[key].InsertInHierarchy(keyHierarchy, value);
                return;
            }
            // If we are on the last level, just insert the node with it's value.
            this.Children.Add(keyHierarchy[0], new JSONNode(keyHierarchy[0], value));
        }
        /// <summary>
        /// Gets the textual representation of this node as JSON entry.
        /// </summary>
        /// <returns>A textual representaiton of this node as JSON entry.</returns>
        public string ToJSONEntry()
        {
            // If there is no child, return the name and the value in JSON format.
            if (this.Children.Count == 0)
            {
                return string.Format("\"{0}\":\"{1}\"", this.Name, this.Value);
            }
            // Otherwise there are childs so return all of them formatted as object.
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("\"{0}\":", this.Name);
            builder.Append(this.ToJSONObject());
            return builder.ToString();
        }
        /// <summary>
        /// Gets the textual representation of this node as JSON object.
        /// </summary>
        /// <returns>A textual representaiton of this node as JSON object.</returns>
        public string ToJSONObject()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            foreach (JSONNode value in this.Children.Values)
            {
                builder.Append(value.ToJSONEntry());
                builder.Append(",");
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append("}");
            return builder.ToString();
        }
    }
