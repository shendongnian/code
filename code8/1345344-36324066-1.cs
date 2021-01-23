		Button button = FindViewById<Button> (Resource.Id.myButton);
		var count = 0;
		var handled = false;
		button.Touch += (s, e) => {
			if(e.Event.Action == Android.Views.MotionEventActions.Down)
			{
				// Do stuff.
				System.Console.WriteLine("Counting ... " + count.ToString());
				count++;
				handled = true;
			}
			else if (e.Event.Action == Android.Views.MotionEventActions.Up)
			{
				// Do stuff.
				System.Console.WriteLine("Counting ... " + count.ToString());
				count++;
				handled = true;
			}
			e.Handled = handled;
		};
