    var result = models.GroupBy(m => new 
                                    { 
                                        A = Math.Min(m.StudentID_FK, m.AssistantID_FK),  // This gets pairs like (1, 2) and (2, 1)
                                        B = Math.Max(m.StudentID_FK, m.AssistantID_FK)   // as the same (1, 2)
                                    })
                        .OrderBy(g => g.Count())
                        .SelectMany(g => g)
                        .ToList();
