    		    Using tempForest = ActiveDirectory.Forest.GetCurrentForest()
                    For Each domain As ActiveDirectory.Domain In tempForest.Domains
                        context = New PrincipalContext(ContextType.Domain, domain.Name)
                        Using userPrin As New UserPrincipal(context)
                            userPrin.Enabled = True
                            userPrin.EmailAddress = "*"
                            Using searcher = New PrincipalSearcher(New UserPrincipal(context))
                                searcher.QueryFilter = userPrin
                                Using results As PrincipalSearchResult(Of Principal) = searcher.FindAll
                                    Trace.WriteLine("results.count: " & results.Count)
                                    userPrincipalResult = (From r In results Select TryCast(r, UserPrincipal))
                                    Trace.WriteLine("userPrincipalResult.Count: " & userPrincipalResult.Count)
                                    userList = (From cr In userPrincipalResult Select cr.EmailAddress).ToList()
                                End Using
                            End Using
                        End Using
                    Next
                End Using
