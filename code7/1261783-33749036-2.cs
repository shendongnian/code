    {
        if (Parallel.ForEach(concurentDictionary, (item, loopState) =>
            {
                Timer timer = new Timer(callback => { loopState.Stop(); }, null, 60 * 1000, Timeout.Infinite);
                            
                try
                {
                    if (loopState.ShouldExitCurrentIteration || loopState.IsExceptional)
                        loopState.Stop();
    
                    var mailObject = dbContext.MailObjects.Where(x => x.MailObjectId == item.key).Select(y => y);
                    mailObject.MailBody = ConvertToPdf(item.Value.MailBody);
    
                    if (loopState.ShouldExitCurrentIteration || loopState.IsExceptional)
                        loopState.Stop();
                }
                catch (Exception)
                {
                    loopState.Stop();
                    throw;
                }
                finally
                {
                    timer.Dispose();
                }
            }
        ).IsCompleted)
        {
            // All events complete
        }
    
    }
    catch (AggregateException)
    {
        // Execution will not get to this point until all of the iterations have completed (or one 
        // has failed, and all that were running when that failure occurred complete).
    }
