                    var user = ParseUser.Query.WhereEqualTo("username", result.ToString());
                    IEnumerable<ParseObject> resultnumber = await user.FindAsync();
                    if (resultnumber.Count() != 0)
                    {
                        textblockstring = "user exists";
                    }
                    else
                    {
                        textblockstring = "user doesn't exist";
                    }
                }
                catch (ParseException e)
                {
                    if (e.Code == ParseException.ErrorCode.ObjectNotFound)
                    {
                        textblockstring = e.Message.ToString();
                        //textblockstring = "user doesn't exist";
                    }
                    else
                    {
                        textblockstring = e.Message.ToString();
                    }
                }`
