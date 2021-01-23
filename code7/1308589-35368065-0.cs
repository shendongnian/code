    documentStore.DatabaseCommands.Patch("yourDocId/1",
                        new[] 
                        { 
                            new PatchRequest
                            {
                                Type = PatchCommandType.Modify,
                                Name = "User",
                                AllPositions = true,
                                Nested = new []
                                {                                   
                                     new PatchRequest
                                     {
                                          Type = PatchCommandType.Unset,
                                          Name = "$type"
                                     }                                    
                                }
                            },
                            new PatchRequest
                            {
                                Type = PatchCommandType.Modify,
                                Name = "Content",
                                AllPositions = true,
                                Nested = new []
                                {
                                    new PatchRequest
                                    {
                                        Type = PatchCommandType.Modify,
                                        Name = "Additional",
                                        AllPositions = true,
                                        Nested = new []
                                        {
                                            new PatchRequest
                                            {
                                                Type = PatchCommandType.Unset,
                                                Name = "$type"
                                            }
                                        }
                                    }
                                }
                            }
                        });
