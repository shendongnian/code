    	/// <summary>Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.</summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
		protected override void Dispose(bool disposing)
		{
			if (this.GetState(2097152))
			{
				object @object = this.Properties.GetObject(Control.PropBackBrush);
				if (@object != null)
				{
					IntPtr intPtr = (IntPtr)@object;
					if (intPtr != IntPtr.Zero)
					{
						SafeNativeMethods.DeleteObject(new HandleRef(this, intPtr));
					}
					this.Properties.SetObject(Control.PropBackBrush, null);
				}
			}
			this.UpdateReflectParent(false);
			if (disposing)
			{
				if (this.GetState(4096))
				{
					return;
				}
				if (this.GetState(262144))
				{
					throw new InvalidOperationException(SR.GetString("ClosingWhileCreatingHandle", new object[]
					{
						"Dispose"
					}));
				}
				this.SetState(4096, true);
				this.SuspendLayout();
				try
				{
					this.DisposeAxControls();
					ContextMenu contextMenu = (ContextMenu)this.Properties.GetObject(Control.PropContextMenu);
					if (contextMenu != null)
					{
						contextMenu.Disposed -= new EventHandler(this.DetachContextMenu);
					}
					this.ResetBindings();
					if (this.IsHandleCreated)
					{
						this.DestroyHandle();
					}
					if (this.parent != null)
					{
						this.parent.Controls.Remove(this);
					}
					Control.ControlCollection controlCollection = (Control.ControlCollection)this.Properties.GetObject(Control.PropControlsCollection);
					if (controlCollection != null)
					{
						for (int i = 0; i < controlCollection.Count; i++)
						{
							Control control = controlCollection[i];
							control.parent = null;
							control.Dispose();
						}
						this.Properties.SetObject(Control.PropControlsCollection, null);
					}
					base.Dispose(disposing);
					return;
				}
				finally
				{
					this.ResumeLayout(false);
					this.SetState(4096, false);
					this.SetState(2048, true);
				}
			}
			if (this.window != null)
			{
				this.window.ForceExitMessageLoop();
			}
			base.Dispose(disposing);
		}
