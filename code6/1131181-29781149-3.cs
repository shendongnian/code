    public class UpdatePlayer : Form
    {
        List<GroupsPlayers> _GroupPlayers;
        UpdatePlayer (List<GroupsPlayers> GroupPlayers)
        {
            _GroupPlayers = GroupPlayers; // here You are "Catching" the value You have passed in first form and assigning it to _GroupPlayers property
        }
    }
