    /// <include file='doc\Control.uex' path='docs/doc[@for="Control.Invalidate3"]/*' />
    /// <devdoc>
    ///     Invalidates the control and causes a paint message to be sent to the control.
    ///     This will not force a synchronous paint to occur, calling update after
    ///     invalidate will force a synchronous paint.
    /// </devdoc>
    public void Invalidate(bool invalidateChildren)
    {
        if (IsHandleCreated)
        {
            if (invalidateChildren)
            {
                SafeNativeMethods.RedrawWindow(new HandleRef(window, Handle),
                                                null, NativeMethods.NullHandleRef,
                                                NativeMethods.RDW_INVALIDATE |
                                                NativeMethods.RDW_ERASE |
                                                NativeMethods.RDW_ALLCHILDREN);
            }
            else
            {
                // It's safe to invoke InvalidateRect from a separate thread.
                using (new MultithreadSafeCallScope())
                {
                    SafeNativeMethods.InvalidateRect(new HandleRef(window, Handle),
                                                        null,
                                                        (controlStyle & ControlStyles.Opaque) != ControlStyles.Opaque);
                }
            }
    
            NotifyInvalidate(this.ClientRectangle);
        }
    }
