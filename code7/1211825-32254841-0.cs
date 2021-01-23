     Resuming += (s, e) => { OnResuming(s, e); };
                Suspending += async (s, e) =>
                {
                    // one, global deferral
                    var deferral = e.SuspendingOperation.GetDeferral();
                    try
                    {
                        foreach (var service in WindowWrapper.ActiveWrappers.SelectMany(x => x.NavigationServices))
                        {
                            // date the cache (which marks the date/time it was suspended)
                            service.FrameFacade.SetFrameState(CacheDateKey, DateTime.Now.ToString());
                            // call view model suspend (OnNavigatedfrom)
                            await service.SuspendingAsync();
                        }
                        // call system-level suspend
                        await OnSuspendingAsync(s, e);
                    }
                    catch { }
                    finally { deferral.Complete(); }
                };
