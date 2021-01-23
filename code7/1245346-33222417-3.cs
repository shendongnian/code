        protected virtual void SetVisibleCore(bool value) {
            try {
                System.Internal.HandleCollector.SuspendCollect();
 
                if (GetVisibleCore() != value) {
                    if (!value) {
                        SelectNextIfFocused();
                    }
 
                    bool fireChange = false;
 
                    if (GetTopLevel()) {
 
                        // The processing of WmShowWindow will set the visibility
                        // bit and call CreateControl()
                        //
                        if (IsHandleCreated || value) {
                                SafeNativeMethods.ShowWindow(new HandleRef(this, Handle), value ? ShowParams : NativeMethods.SW_HIDE);
                        }
                    }
                    else if (IsHandleCreated || value && parent != null && parent.Created) {
 
                        // We want to mark the control as visible so that CreateControl
                        // knows that we are going to be displayed... however in case
                        // an exception is thrown, we need to back the change out.
                        //
                        SetState(STATE_VISIBLE, value);
                        fireChange = true;
                        try {
                            if (value) CreateControl();
                            SafeNativeMethods.SetWindowPos(new HandleRef(window, Handle),
                                                           NativeMethods.NullHandleRef,
                                                           0, 0, 0, 0,
                                                           NativeMethods.SWP_NOSIZE
                                                           | NativeMethods.SWP_NOMOVE
                                                           | NativeMethods.SWP_NOZORDER
                                                           | NativeMethods.SWP_NOACTIVATE
                                                           | (value ? NativeMethods.SWP_SHOWWINDOW : NativeMethods.SWP_HIDEWINDOW));
                        }
                        catch {
                            SetState(STATE_VISIBLE, !value);
                            throw;
                        }
                    }
                    if (GetVisibleCore() != value) {
                        SetState(STATE_VISIBLE, value);
                        fireChange = true;
                    }
 
                    if (fireChange) {
                        // We do not do this in the OnPropertyChanged event for visible
                        // Lots of things could cause us to become visible, including a
                        // parent window.  We do not want to indescriminiately layout
                        // due to this, but we do want to layout if the user changed
                        // our visibility.
                        //
 
                        using (new LayoutTransaction(parent, this, PropertyNames.Visible)) {
                            OnVisibleChanged(EventArgs.Empty);
                        }
                    }
                    UpdateRoot();
                }
                else { // value of Visible property not changed, but raw bit may have
 
                    if (!GetState(STATE_VISIBLE) && !value && IsHandleCreated) {
                        // PERF - setting Visible=false twice can get us into this else block
                        // which makes us process WM_WINDOWPOS* messages - make sure we've already 
                        // visible=false - if not, make it so.
                         if (!SafeNativeMethods.IsWindowVisible(new HandleRef(this,this.Handle))) {
                            // we're already invisible - bail.
                            return;
                         }
                    }
                    
                    SetState(STATE_VISIBLE, value);
 
                    // If the handle is already created, we need to update the window style.
                    // This situation occurs when the parent control is not currently visible,
                    // but the child control has already been created.
                    //
                    if (IsHandleCreated) {
                       
                        SafeNativeMethods.SetWindowPos(
                                                          new HandleRef(window, Handle), NativeMethods.NullHandleRef, 0, 0, 0, 0, NativeMethods.SWP_NOSIZE |
                                                          NativeMethods.SWP_NOMOVE | NativeMethods.SWP_NOZORDER | NativeMethods.SWP_NOACTIVATE |
                                                          (value ? NativeMethods.SWP_SHOWWINDOW : NativeMethods.SWP_HIDEWINDOW));
                    }
                }
            }
            finally {
                System.Internal.HandleCollector.ResumeCollect();
            }
        }
