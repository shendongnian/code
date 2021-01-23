        [JsonProperty]
        public bool[,] discoveredTiles
        {
            get
            {
                return m_Discovered;
            }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException();
                // Ensure the tiles and discoveredTiles arrays have the same sizes
                if (tiles != null && tiles.GetLength(0) != value.GetLength(0) || tiles.GetLength(1) != value.GetLength(1))
                    throw new InvalidOperationException("tiles != null && tiles.GetLength(0) != value.GetLength(0) || tiles.GetLength(1) != value.GetLength(1)");
                m_Discovered = value;
            }
        }
