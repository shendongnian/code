        async Task fireShipCannons(CancellationToken ct)
        {
            var start = DateTime.Now;
            while (bullet.isOnscreen) {
               drawBitmap(bullet);
               var sleep = (start.Add(TimeSpan.FromMilliseconds(100.0)) - DateTime.Now);
               if (sleep.Milliseconds > 0) {
                   Task.Delay(sleep, ct);
               }
               iter = (int)((DateTime.Now - start).TotalMilliseconds / 100 + 0.5);
               bullet.moveSteps(iter); // move it iter steps.
               var start = start.AddMilliseconds(100 * it);
           }
        }
