	public class DllUpdateEventArgs: EventArgs {
		public string UpdateDescription { get; set; }
	}
	public class Dll {
		public event EventHandler<DllUpdateEventArgs> Updated;
		private void OnUpdated(string updateDescription) {
			var updated = Updated;
			if (updated != null) {
				updated(this, new DllUpdateEventArgs { UpdateDescription = updateDescription });
			}
		}
		
		public void DoDatabaseFunctions() {
			// Do things
			OnUpdated("Step 1 done");
			// Do more things
			OnUpdated("Step 2 done");
			// Do even more things
			OnUpdated("Step 3 done");
		}
	}
