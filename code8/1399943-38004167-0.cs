        public async static Task UpdateBayPositionAsync(string cadCnn, string serializedBayPositions)
        {
            string[] bayPositionsAsStrings = serializedBayPositions.Split(',');
            List<BayPosition> bayPositions = bayPositionsAsStrings.Select(bp => new BayPosition(cadCnn, bp)).ToList();
            Task.Factory.StartNew( () => Parallel.ForEach(bayPositions, item => item.Update()));
        }
        public class BayPosition
        {
            public int BId { get; private set; }
            public byte Pos { get; private set; }
            public string CadCnn { get; private set; }
            public BayPosition(string cadCnn, string bayPosition)
            {
                string[] parameters = bayPosition.Split(':');
                BId = Int32.Parse(parameters[0]);
                Pos = Byte.Parse(parameters[1]);
                CadCnn = cadCnn;
            }
            public void Update()
            {
                ElevationManagerDL.UpdateBayPosition(CadCnn, BId, Pos);
            }
        }
