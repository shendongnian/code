	public async Task<bool> DeletePost(string update_id, string authId)
	{
		if (Utility.NetworkStatus.HasInternetAccess)
		{
			return await APIs.DeletePost.DeletePostAPI(update_id, authId).ContinueWith((t) =>
			{
				if (t.Status == TaskStatus.RanToCompletion)
				{
					if (t.Result != null)
					{
						return t.Result.status == 200;
					}
					else
					{
						return false;
						//empty result, API failed
						//not implemented
					}
				}
				else
				{
					return false;
					//task failed 
					//not implemented
				}
			});
		}
		else
		{
			return false;
			//no network
			//not implemented
		}
	}
