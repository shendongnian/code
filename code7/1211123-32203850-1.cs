    /// <summary>Destroys the handle associated with the control.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected virtual void DestroyHandle()
		{
			if (this.RecreatingHandle && this.threadCallbackList != null)
			{
				lock (this.threadCallbackList)
				{
					if (Control.threadCallbackMessage != 0)
					{
						NativeMethods.MSG mSG = default(NativeMethods.MSG);
						if (UnsafeNativeMethods.PeekMessage(ref mSG, new HandleRef(this, this.Handle), Control.threadCallbackMessage, Control.threadCallbackMessage, 0))
						{
							this.SetState(32768, true);
						}
					}
				}
			}
			if (!this.RecreatingHandle && this.threadCallbackList != null)
			{
				lock (this.threadCallbackList)
				{
					Exception exception = new ObjectDisposedException(base.GetType().Name);
					while (this.threadCallbackList.Count > 0)
					{
						Control.ThreadMethodEntry threadMethodEntry = (Control.ThreadMethodEntry)this.threadCallbackList.Dequeue();
						threadMethodEntry.exception = exception;
						threadMethodEntry.Complete();
					}
				}
			}
			if ((64 & (int)((long)UnsafeNativeMethods.GetWindowLong(new HandleRef(this.window, this.InternalHandle), -20))) != 0)
			{
				UnsafeNativeMethods.DefMDIChildProc(this.InternalHandle, 16, IntPtr.Zero, IntPtr.Zero);
			}
			else
			{
				this.window.DestroyHandle();
			}
			this.trackMouseEvent = null;
		}
