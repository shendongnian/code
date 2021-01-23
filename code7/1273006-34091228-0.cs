    long milliSeconds = 0;
			var tapCount = 0;
            var millisecondsPeriod = 200;
			button.Click += (object sender, EventArgs e) => {
				if (milliSeconds == 0) {
					milliSeconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
					tapCount++;
				} else {
					var currMill = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - milliSeconds;
					if (currMill < millisecondsPeriod) {
						milliSeconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
						tapCount++;
						if (tapCount == 3) {
							Toast.MakeText (this, "triple", ToastLength.Long).Show ();
						}
					} else {
						tapCount = 0;
						milliSeconds = 0;
					}
				}
			};
