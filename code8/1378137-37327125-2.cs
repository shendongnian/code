            public void addRoute()
        {
            if (!coords.isWrongCoords())
            {
                Console.WriteLine("Route");
                route.Points.Add(coords.get_position());
                overlay.Routes.Add(route);
                mainForm.reloadMapOverlay(overlay);
            }
        }
