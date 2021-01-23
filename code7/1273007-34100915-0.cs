                DateTime _firstTap;
                int _tapCount = 0;
                const int TAP_COUNT_TRESHOLD = 5; //number of taps
                const int TIME_TRESHOLD 200; //ms time
                protected override void OnResume()
                {
                    myButton.Clicked += ButtonTapped;
                }
                protected override void OnPause()
                {
                    myButton.Clicked -= ButtonTapped;
                }
                void ButtonTapped(object sender, EventArgs e){
                    var time = Math.Round((DateTime.Now - _firstTap).TotalMilliseconds, MidpointRounding.AwayFromZero);
                    if (time > TIME_TRESHOLD)
                    {
                        _tapCount = 1;
                        _firstTap = DateTime.Now;
                    }
                    else
                        _tapCount++;
                    if (_tapCount == TAP_COUNT_TRESHOLD)
                    {
                       //do your logic here
                    }
                }
