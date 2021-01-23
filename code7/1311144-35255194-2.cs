    	public static void LogScoreInGameService(int score, string leaderBoard)
		{
			if (!PlayGamesPlatform.Instance.localUser.authenticated)
			{
				return;
			}
			PlayGamesPlatform.Instance.ReportScore(score, leaderBoard, (bool success) =>
			{
				if (success)
				{
					Debug.Log("log to leaderboard succeeded");
				}
				else
				{
					Debug.Log("log to leaderboard failed");
				}
			});
		}
