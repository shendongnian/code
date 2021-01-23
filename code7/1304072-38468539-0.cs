                    GooglePlayGames.OurUtils.PlayGamesHelperObject.RunOnGameThread(() => {
                        PlayGamesPlatform.Instance.GetServerAuthCode((CommonStatusCodes status, string code) =>
                        {                            
                            Debug.Log("Status: " + status.ToString());
                            Debug.Log("Code: " + code);
                            
                        });
                                               
                    });
