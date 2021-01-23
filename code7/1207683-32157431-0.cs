    public async Task<bool> DeletePost(string update_id, string authId)
    {
      if (Utility.NetworkStatus.HasInternetAccess)
      {
        try
        {
          var result = await APIs.DeletePost.DeletePostAPI(update_id, authId);
          if (result != null)
          {
            return result.status == 200;
          }
          else
          {
            return false;
            //empty result, API failed
            //not implemented
          }
        }
        catch
        {
          return false;
          //task failed 
          //not implemented
        }
      }
      else
      {
        return false;
        //no network
        //not implemented
      }
    }
