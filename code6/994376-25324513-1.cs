        public class PlayerDto
        {
            public PlayerDto(Player player)
            {
                FirstName = player.FirstName;
                LastName = player.LastName;
                TeamName = player.Team.Name;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string TeamName { get; set; }
        }
