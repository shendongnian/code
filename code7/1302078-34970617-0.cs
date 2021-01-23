        private World()
        {
            this.gameResources = new GameResources();
            this.tileFactory = new SimpleTileFactory();
            for (int i = 0; i < this.worldSize.Height; i++)
            {
                List<Tile> row = new List<Tile>();
                for (int j = 0; j < this.worldSize.Width; j++)
                {
                    row.Add(tileFactory.createTile(new Point(j, i), this));
                }
                this.tiles.Add(row);
            }
        }
