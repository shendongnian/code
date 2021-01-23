    var primaryScreen = System.Windows.Forms.Screen
                                            .AllScreens
                                            .Where(s => s.Primary)
                                            .FirstOrDefault();
    
    var secondaryScreen = System.Windows.Forms.Screen
                                              .AllScreens
                                              .Where(s => !s.Primary)
                                              .FirstOrDefault();
