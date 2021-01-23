    public Dispatcher dispacher = Dispatcher.CurrentDispatcher;
    public void reloadMapOverlay(GMapOverlay overlay)
                {
                    try
                    {
                        dispacher.Invoke(new Action(() => this.map_Box.Overlays.Add(overlay)));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("reloadMapOverlay: {0}", e);
                        this.setError("reloadMapOverlay: " + e);
                    }
                } 
