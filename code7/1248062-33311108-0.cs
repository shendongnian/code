            Line[] keysLineCollection = YAxisKeys.Children.OfType<Line>().ToArray();
            Label[] keysLabelCollection = YAxisKeys.Children.OfType<Label>().ToArray();
            try
            {
                new Thread(delegate ()
                {
                    Parallel.ForEach(keysLineCollection, (line, loopstate, elementIndex) =>
                    {
                        /*keysLineCollection[elementIndex]*/
                        line.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Double topProp = ((Double)line.GetValue(Canvas.TopProperty) - 11.0) * hDelta + 11.0;
                            switch (topProp - 11.0 < 0)
                            {
                                case true:
                                    line.Visibility = Visibility.Hidden;
                                    break;
                                default:
                                    line.Visibility = Visibility.Visible;
                                    break;
                            }
                            line.SetValue(Canvas.TopProperty, topProp);
                        }));
                        keysLineCollection[elementIndex] = line;
                    });
                }).Start();
                new Thread(delegate ()
                {
                    Parallel.ForEach(keysLabelCollection, (label, loopstate, elementIndex) =>
                    {
                        /*keysLabelCollection[elementIndex]*/
                        label.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Double topProp = (Double)label.GetValue(Canvas.TopProperty) * hDelta;
                            switch (topProp < 0)
                            {
                                case true:
                                    label.Visibility = Visibility.Hidden;
                                    break;
                                default:
                                    label.Visibility = Visibility.Visible;
                                    break;
                            }
                            label.SetValue(Canvas.TopProperty, topProp);
                        }));
                        keysLabelCollection[elementIndex] = label;
                    });
                }).Start();
            }
            catch (AggregateException ae)
            {
                ae.Handle((x) =>
                {
                    if (x is Exception)
                    {
                        MessageBox.Show(x.ToString(), "error");
                    }
                    return false;
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "error");
            }
