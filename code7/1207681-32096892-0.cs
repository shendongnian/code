    bool result = await APIs.DeletePost.DeletePostAPI(update_id, authId).ContinueWith((t) =>
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
    return result;
