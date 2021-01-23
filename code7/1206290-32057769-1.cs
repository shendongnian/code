	public int progress {
		set {
			if (progressBar.InvokeRequired) {
				this.Invoke(() => progressBar.Increment(value));
			} else {
				progressBar.Increment(value);
			}
		}
	}
