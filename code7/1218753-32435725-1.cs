	public class PauseTokenSource {
		internal static readonly Task s_completedTask = Task.FromResult(true);
		volatile TaskCompletionSource<bool> m_paused;
		#pragma warning disable 420
		public bool IsPaused { 
			get { return m_paused != null; } 
			set { 
				if (value) { 
					Interlocked.CompareExchange(
						ref m_paused, new TaskCompletionSource<bool>(), null); 
				} else { 
					while (true) { 
						var tcs = m_paused; 
						if (tcs == null)
							return; 
						if (Interlocked.CompareExchange(ref m_paused, null, tcs) == tcs) { 
							tcs.SetResult(true); 
							break; 
						} 
					} 
				} 
			} 
		}
		#pragma warning restore 420
		public PauseToken Token { get { return new PauseToken(this); } }
		internal Task WaitWhilePausedAsync() { 
			var cur = m_paused; 
			return cur != null ? cur.Task : s_completedTask; 
		}
	}
	public struct PauseToken {
		readonly PauseTokenSource m_source;
		internal PauseToken(PauseTokenSource source) {
			m_source = source;
		}
		public bool IsPaused { get { return m_source != null && m_source.IsPaused; } }
		public Task WaitWhilePausedAsync() { 
			return IsPaused ? 
				m_source.WaitWhilePausedAsync() : 
				PauseTokenSource.s_completedTask; 
		}
	}
