     TextBlock tb = new TextBlock();
                        tb.TextWrapping = TextWrapping.Wrap;
                        tb.Margin = new Thickness(10);
                        tb.Inlines.Add("<xml...> ");
                        tb.Inlines.Add(new Run("<Configuration ") 
                                           { 
                                             FontWeight = FontWeights.Bold,
                                             Foreground = Brushes.Blue });
                        tb.Inlines.Add(new Run( new LineBreak())....
