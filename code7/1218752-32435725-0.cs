	class RetainedFragment : Fragment {
		readonly PauseTokenSource pts = new PauseTokenSource();
		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			RetainInstance = true;
		}
		public override void OnPause() {
			base.OnPause();
			pts.IsPaused = true;
		}
		public override void OnResume() {
			base.OnResume();
			pts.IsPaused = false;
		}
		public void doIt() {
			doItAsync();	
		}
		public async Task doItAsync() {
			try {
				await Task.Delay(3000); // substitute for the real operation
				await pts.WaitWhilePausedAsync();
				(Activity as MainActivity).taskFinished();
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}
    }
