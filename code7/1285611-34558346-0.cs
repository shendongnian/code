			StringBuilder query = new StringBuilder("INSERT IGNORE INTO winners(giveaway_id, winner_id) VALUES");
            foreach (ulong winnerID in winners) {
				query.Append("(@giveawayID, " + winnerID + "),");
			}
			query.Length -= 1; // Remove last char ',' from values
			MySqlParameter[] parameters = {
				new MySqlParameter("@giveawayID", giveawayID)
			};
			await ExecuteNonQueryRetryAsync(query.ToString(), parameters).ConfigureAwait(false);
