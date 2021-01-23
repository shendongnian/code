    /// <summary>
        /// When a game is over, recive a gameState and update the user. 1 for a win, 2 for loss, 3 for aa draw
        /// </summary>
        /// <param name="gameState"></param>
        private async Task UpdateUserGameState(int gameState, string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            switch (gameState)
            {
                case 1:
    
                    user.GamesWon++;
                    break;
    
                case 2:
                    user.GamesLost++;
                    break;
    
                case 3:
                    user.GamesDraw++;
                    break;
                default:
                    break;
    
            }
           //add missing await
           await UserManager.UpdateAsync(user);
        }
